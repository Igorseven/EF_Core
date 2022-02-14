using EFCore.Business.Response;
using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace EFCore.Business.Interfaces.ValidationContext
{
    public interface IDomainValidation
    {
        public ValidationResult ValidationResult { get; set; }
        bool Validate<TEntity>(TEntity entity, AbstractValidator<TEntity> validator);
        Task<bool> ValidateAsync<TEntity>(TEntity entity, AbstractValidator<TEntity> validator);
        ValidationResponse Validation();
    }
}
