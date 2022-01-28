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
    public class Validate<TEntity> : AbstractValidator<TEntity> ,IValidation<TEntity> where TEntity : class
    {
        private ValidationResult ValidationResult { get; set; }

        private Dictionary<string, string> GetErros() => ValidationResult.Errors.ToDictionary();
        private void CreateResult(TEntity entity) => ValidationResult = base.Validate(entity);
        private async Task CreateResultAsync(TEntity entity) => ValidationResult = await ValidateAsync(entity);

        public ValidationResponse Validation(TEntity entity)
        {
            CreateResult(entity);
            return ValidationResponse.CreateValidation(GetErros());
        }

        public async Task<ValidationResponse> ValidationAsync(TEntity entity)
        {
            await CreateResultAsync(entity);
            return ValidationResponse.CreateValidation(GetErros());
        }
    }
}
