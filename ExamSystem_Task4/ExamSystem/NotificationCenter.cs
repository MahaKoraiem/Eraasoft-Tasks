using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal class NotificationCenter
    {
        
        private static NotificationCenter _instance = new();
        public static NotificationCenter Instance => _instance ??= new NotificationCenter();

        private readonly Dictionary<string, List<string>> _notifications = new();



        public void AddNotification(string username ,string message)
        {
            if (!_notifications.ContainsKey(username))
                _notifications[username] = new List<string>();
            _notifications[username].Add($"[{DateTime.Now:T}] {message}");
        }

        public List<string> GetNotifications(string username)
        {
            return _notifications.ContainsKey(username)
            ? new List<string>(_notifications[username])
            : new List<string>();
        }


    }
}
