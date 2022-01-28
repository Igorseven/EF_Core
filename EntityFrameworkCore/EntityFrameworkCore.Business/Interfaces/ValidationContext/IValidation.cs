using EFCore.Business.Response;
using System.Threading.Tasks;

namespace EFCore.Business.Interfaces.ValidationContext
{
    public interface IValidation<TEntity> where TEntity : class
    {
        ValidationResponse Validation(TEntity entity);
        Task<ValidationResponse> ValidationAsync(TEntity entity);
    }
}
