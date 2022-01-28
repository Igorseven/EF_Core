using EFCore.Domain.Entities;
using EFCore.Domain.Enums;
using EFCore.Domain.Extention;
using FluentValidation;

namespace EFCore.Business.Validation.Entities
{
    public class ManufacturerValidation : Validate<Manufacturer>
    {
        public ManufacturerValidation()
        {
            CreateRules();
        }

        private void CreateRules()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage(EMessage.Required.Description());
            RuleFor(m => m.Name).Length(3, 50).WithMessage(EMessage.MoreExpected
                .Description().ToFormatMessage("Manufacturer Name", "3 to 50"));
        }
    }
}
