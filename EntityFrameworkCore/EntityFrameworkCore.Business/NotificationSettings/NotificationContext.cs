using EFCore.Business.Interfaces.NotificationContext;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.Business.NotificationSettings
{
    public class NotificationContext : INotificationContext
    {
        private readonly List<DomainNotification> _notifications;

        public NotificationContext()
        {
            this._notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotification() => this._notifications;

        public bool HasNotification() => this._notifications.Any();

        public void AddNotification(string key, string value)
        {
            this._notifications.Add(new DomainNotification(key, value));
        }

        public void AddNotification(DomainNotification notification)
        {
            this._notifications.Add(notification);
        }

        public void AddNotifications(IList<DomainNotification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AddNotification(erro.ErrorCode, erro.ErrorMessage);
            }
        }

       
    }
}
