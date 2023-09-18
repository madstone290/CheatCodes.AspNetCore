using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace WebSocketChat.Core
{
    public class ChatManager
    {
        private readonly ConcurrentDictionary<string, WebSocket> _sockets = new();

        public async Task OnConnected(WebSocket socket, string userName)
        {
            // add the new user to the list of connected users
            // if the user already exists, disconnect current connection
            bool success = _sockets.TryAdd(userName, socket);
            if (!success)
            {
                await HandleDisconnect(userName, false);
                return;
            }

            // notify all clients that a new user has joined
            ServerMessage join = ServerMessage.Connected(userName);
            await Broadcast(join);

            try
            {
                while (socket.State == WebSocketState.Open)
                {
                    var buffer = new byte[1024 * 4];
                    var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer),
                                                           cancellationToken: CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        // client has requested to close the socket
                        await HandleDisconnect(userName);

                        // notify all clients that a user has left
                        ServerMessage left = ServerMessage.Disconnected(userName);
                        await Broadcast(left);
                    }
                    else
                    {
                        // client has sent a message. broadcast it to all clients
                        await HandleMessage(buffer, result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await HandleDisconnect(userName);
            }

        }

        private async Task HandleMessage(byte[] buffer, WebSocketReceiveResult result)
        {
            string rawText = Encoding.UTF8.GetString(buffer, 0, result.Count);
            ClientMessage clientMessage = JsonSerializer.Deserialize<ClientMessage>(rawText);
            ServerMessage serverMessage = ServerMessage.FromCleint(clientMessage);

            await Broadcast(serverMessage);
        }

        /// <summary>
        /// Broadcasts a message to all connected clients
        /// </summary>
        /// <param name="serverMessage"></param>
        /// <returns></returns>
        private async Task Broadcast(ServerMessage serverMessage)
        {
            var responseMessageText = JsonSerializer.Serialize(serverMessage);
            var responseBytes = Encoding.UTF8.GetBytes(responseMessageText);

            foreach (var pair in _sockets)
            {
                var receiver = pair.Value;

                if (receiver.State == WebSocketState.Open)
                {
                    await receiver.SendAsync(new ArraySegment<byte>(responseBytes, 0, responseBytes.Length),
                        WebSocketMessageType.Text,
                        true,
                        CancellationToken.None);
                }
            }
        }

        private async Task HandleDisconnect(string userName, bool remove = true)
        {
            var socket = _sockets[userName];
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by the WebSocketManager", CancellationToken.None);

            if (remove)
            {
                _sockets.TryRemove(userName, out _);
            }
        }
    }
}

