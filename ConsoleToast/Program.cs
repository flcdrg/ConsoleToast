using System;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace ConsoleToast
{
    class Program
    {
        static void Main(string[] args)
        {
            string notificationTitle = "Notification " + DateTime.Now.ToShortTimeString();

            XmlDocument template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);

            var textNodes = template.GetElementsByTagName("text").ToList();
            foreach (var textNode in textNodes)
            {
                textNode.AppendChild(template.CreateTextNode(notificationTitle));
            }

            var toast = new ToastNotification(template);
            toast.Tag = "Console App";
            toast.Group = "C#";
            toast.ExpirationTime = DateTimeOffset.Now.AddMinutes(5);

            var notifier = ToastNotificationManager.CreateToastNotifier("ConsoleToast");
            notifier.Show(toast);

        }
    }
}
