namespace WebSocketChat.Core
{
    /// <summary>
    /// A message from the client
    /// </summary>
    public class ClientMessage
    {
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
