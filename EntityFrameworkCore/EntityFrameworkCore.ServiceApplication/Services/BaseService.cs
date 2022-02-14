using EFCore.Business.Interfaces.NotificationContext;
using EFCore.Business.Interfaces.ValidationContext;
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

            var entityResult = await _validation.ValidateAsync(entity, validate);

            if (!entityResult)
            {
                this._notification.AddNotifications(_validation.ValidationResult);
            }

            return entityResult;
        }
    }
}
