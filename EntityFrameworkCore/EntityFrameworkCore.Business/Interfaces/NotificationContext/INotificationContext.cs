using EFCore.Business.NotificationSettings;
using FluentValidation.Results;
using System.Collections.Generic;

namespace EFCore.Business.Interfaces.NotificationContext
{
    public interface INotificationContext
    {
        bool HasNotification();
        List<DomainNotification> GetNotification();
        void AddNotification(string key, string value);
        void AddNotification(DomainNotification notification);
        void AddNotifications(IList<DomainNotification> notifications);
        void AddNotifications(ValidationResult validationResult);
    }
}
