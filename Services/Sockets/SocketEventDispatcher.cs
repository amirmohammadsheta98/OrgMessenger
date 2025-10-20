namespace OrgMessenger.Services.Sockets
{
    public static class SocketEventDispatcher
    {
        private static readonly Dictionary<string, List<Action<string>>> _handlers = new();

        public static void Subscribe(string eventName, Action<string> handler)
        {
            if (!_handlers.ContainsKey(eventName))
                _handlers[eventName] = new List<Action<string>>();

            _handlers[eventName].Add(handler);
        }

        public static void Dispatch(string eventName, string data)
        {
            if (_handlers.TryGetValue(eventName, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    handler.Invoke(data);
                }
            }
        }
    }

}
