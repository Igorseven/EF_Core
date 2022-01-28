using EFCore.Domain.Entities;
using EFCore.Domain.Enums;
using EFCore.Domain.Extention;
using FluentValidation;

namespace EFCore.Business.Validation.Entities
{
    public class VehicleValidation : Validate<Vehicle>
    {
        public VehicleValidation()
        {
            CreateRules();
        }

        private void CreateRules()
        {
            RuleFor(v => v.Model).NotEmpty().WithMessage(EMessage.Required.Description());
            RuleFor(v => v.Model).Length(2, 40).WithMessage(EMessage.MoreExpected
                .Description().ToFormatMessage("Model", "2 to 40"));

            RuleFor(v => v.Information).NotEmpty().WithMessage(EMessage.Required.Description());
            RuleFor(v => v.Information).Length(3, 150).WithMessage(EMessage.MoreExpected
                .Description().ToFormatMessage("Information", "3 to 150"));

            RuleFor(v => v.Price).NotEmpty().WithMessage(EMessage.Required.Description());
            RuleFor(v => v.Price).GreaterThan(0).WithMessage(EMessage
                .ValueExpected.Description().ToFormatMessage("Price", "0,00"));
        }
    }
}
