using EFCore.Business.Interfaces.NotificationContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EFCore.API.Filters
{
    public class GetNotificationFilter : ActionFilterAttribute
    {
        private readonly INotificationContext _notification;

        public GetNotificationFilter(INotificationContext notification)
        {
            this._notification = notification;
        }

        public override void OnActionExecuted(ActionExecutedContext actionContext)
        {
            if (this._notification.HasNotification())
            {
                actionContext.Result = new BadRequestObjectResult(this._notification.GetNotification());
            }

            base.OnActionExecuted(actionContext);
        }
    }
}
