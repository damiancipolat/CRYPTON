using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UI.Notifications
{
    public class Notificator
    {
        private List<INotification> _subscribers = new List<INotification>();

        public void Attach(INotification subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Detach(INotification subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify()
        {
            foreach (INotification client in _subscribers)
                client.Update();
        }
    }
}
