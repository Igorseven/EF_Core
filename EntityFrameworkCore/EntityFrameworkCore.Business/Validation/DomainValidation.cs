using EFCore.Business.Interfaces.ValidationContext;
using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace EFCore.Business.Validation
{
    public class DomainValidation: IDomainValidation
    {
        public ValidationResult ValidationResult { get; set; }

        public bool Validate<TEntity>(TEntity entity, AbstractValidator<TEntity> validator)
        {
            this.ValidationResult = validator.Validate(entity);
            return this.ValidationResult.IsValid;
        }

        public async Task<bool> ValidateAsync<TEntity>(TEntity entity, AbstractValidator<TEntity> validator)
        {
            this.ValidationResult = await validator.ValidateAsync(entity);
            return this.ValidationResult.IsValid;
        }
    }
}
