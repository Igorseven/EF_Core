using EFCore.Business.Interfaces.NotificationContext;
using EFCore.Business.Interfaces.ValidationContext;
using EFCore.Domain.Enums;
using EFCore.Domain.Extention;
using System.Threading.Tasks;

namespace EFCore.ServiceApplication.Services
{
    public abstract class BaseService<TEntity> where TEntity : class
    {
        private readonly INotificationContext _notification;
        private readonly IValidation<TEntity> _validation;

        protected BaseService(INotificationContext notification, IValidation<TEntity> validation)
        {
            this._notification = notification;
            this._validation = validation;
        }

        public async Task<bool> ValidatedAsync(TEntity entity)
        {
            if (this._validation is null)
            {
                this._notification.AddNotification("Invalid", EMessage.ErrorNotConfigured.Description());
            }

            var response = await this._validation.ValidationAsync(entity);

            if (!response.Valid)
            {
                this._notification.AddNotification(response.Errors.Keys.ToString(), response.Errors.Values.ToString());
            }

            return response.Valid;
        }
    }
}
