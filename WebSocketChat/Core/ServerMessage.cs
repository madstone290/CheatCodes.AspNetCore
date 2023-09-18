namespace WebSocketChat.Core
{
    /// <summary>
    /// A message from the server
    /// </summary>
    public class ServerMessage
    {
        public static ServerMessage FromCleint(ClientMessage clientMessage)
        {
            return new ServerMessage()
            {
                Content = clientMessage.Content,
                IsBroadcast = clientMessage.IsBroadcast,
                Sender = clientMessage.Sender,
                Receiver = clientMessage.Receiver,
                Type = "Chat"
            };
        }

        public static ServerMessage Connected(string userName)
        {
            return new ServerMessage()
            {
                Content = $"{userName} joined",
                IsBroadcast = true,
                Type = "System",
                Sender = "",
                Receiver = ""
            };
        }

        public static ServerMessage Disconnected(string userName)
        {
            return new ServerMessage()
            {
                Content = $"{userName} left",
                IsBroadcast = true,
                Type = "System",
                Sender = "",
                Receiver = ""
            };
        }

        /// <summary>
        /// Chat or System
        /// </summary>
        public string Type { get; set; } = "Chat";

        /// <summary>
        /// message content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// send to all or a specific user
        /// </summary>
        public bool IsBroadcast { get; set; }

        /// <summary>
        /// message sender
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// message receiver. if IsBroadcast is true, this field is ignored
        /// </summary>
        public string Receiver { get; set; }
    }
}
