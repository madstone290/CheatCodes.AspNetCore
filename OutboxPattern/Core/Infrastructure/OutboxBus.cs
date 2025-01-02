using OutboxPattern.Core.Domain;

namespace OutboxPattern.Core.Infrastructure
{
    /// <summary>
    /// 메시지를 저장하는 인메모리 버스
    /// </summary>
    public static class OutboxBus
    {
        private static readonly List<Guid> _messageGuids = [];


        public static void Add(Guid messagGuid)
        {
            _messageGuids.Add(messagGuid);
        }

        public static List<Guid> Take()
        {
            var messages = _messageGuids.ToList();
            _messageGuids.Clear();
            return messages;
        }

    }
}
