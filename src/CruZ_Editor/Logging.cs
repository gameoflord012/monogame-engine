using System.Runtime.Serialization;

namespace CruZ.Editor
{
    public static class Logging
    {
        public static void PushMsg(string msg)
        {
            while (_msgs.Count > _maxMsg) _msgs.RemoveAt(0);
            _msgs.Add(msg);
        }
        
        public static string[] GetMsgs()
        {
            return _msgs.ToArray();
        }

        static List<string> _msgs = new();
        static int _maxMsg = 10;
    }
}