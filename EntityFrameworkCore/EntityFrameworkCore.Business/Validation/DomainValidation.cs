using EFCore.Business.Interfaces.ValidationContext;
using EFCore.Business.Response;
using EFCore.Domain.Extention;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Business.Validation
{
    public class DomainValidation: IDomainValidation
    {
        private Dictionary<string, string> GetErros() => ValidationResult.Errors.ToDictionary();
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

        public ValidationResponse Validation()
        {
            return ValidationResponse.CreateValidation(GetErros());
        }
    }
}
