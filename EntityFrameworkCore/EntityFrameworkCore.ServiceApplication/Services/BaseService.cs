using EFCore.Business.Interfaces.NotificationContext;
using EFCore.Business.Interfaces.ValidationContext;
using FluentValidation;
using System.Threading.Tasks;

namespace EFCore.ServiceApplication.Services
{
    public abstract class BaseService
    {
        private readonly INotificationContext _notification;
        private readonly IDomainValidation _validation;

        protected BaseService(INotificationContext notification, IDomainValidation validation)
        {
            this._notification = notification;
            this._validation = validation;
        }

        public async Task<bool> ValidatedAsync<TEntity, TValidate>(TEntity entity, TValidate validate) 
            where TEntity : class
            where TValidate : AbstractValidator<TEntity>
        {

            var entityResult = await _validation.ValidateAsync(entity, validate);

            if (!entityResult)
            {
                this._notification.AddNotifications(_validation.ValidationResult);
            }

            return entityResult;
        }
    }
}
