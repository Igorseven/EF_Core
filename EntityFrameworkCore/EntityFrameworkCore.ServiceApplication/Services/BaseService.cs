using EFCore.Business.Interfaces.NotificationContext;
using EFCore.Business.Interfaces.ValidationContext;
using EFCore.Domain.Enums;
using EFCore.Domain.Extention;
using FluentValidation;
using System.Threading.Tasks;

namespace EFCore.ServiceApplication.Services
{
    public abstract class BaseService<TEntity, TValidate> 
        where TEntity : class 
        where TValidate : AbstractValidator<TEntity>
    {
        private readonly INotificationContext _notification;
        private readonly IDomainValidation _validation;

        protected BaseService(INotificationContext notification, IDomainValidation validation)
        {
            this._notification = notification;
            this._validation = validation;
        }

        public async Task<bool> ValidatedAsync(TEntity entity, TValidate validate)
        {
            if (entity is null)
            {
                this._notification.AddNotification("Invalid", EMessage.ErrorNotConfigured.Description());
            }

            await _validation.ValidateAsync(entity, validate);

            var response = this._validation.Validation();

            if (!response.Valid)
            {
                this._notification.AddNotifications(_validation.ValidationResult);
            }

            return response.Valid;
        }
    }
}
