using EFCore.Domain.Entities;
using EFCore.Domain.Enums;
using EFCore.Domain.Extention;
using FluentValidation;

namespace EFCore.Domain.EntitiesValidation
{
    public class ManufacturerValidation : AbstractValidator<Manufacturer>
    {
        public ManufacturerValidation()
        {
            CreateRules();
        }

        private void CreateRules()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage(EMessage.Required.Description());
            RuleFor(m => m.Name).Length(2, 50).WithMessage(EMessage.MoreExpected
                .Description().ToFormatMessage("Manufacturer Name", "3 a 50"));
        }
    }

    
}
