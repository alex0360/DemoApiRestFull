using FluentValidation;

namespace Application.Features.Clients.Commands
{
    public class UpdateClientCommandValidation : AbstractValidator<CreateClientCommand>
    {
        public UpdateClientCommandValidation()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(25).WithMessage("{PropertyName} no puede exceder {MaxLength} caracteres");

            RuleFor(x => x.LastName)
                
                .MaximumLength(25).WithMessage("{PropertyName} no puede exceder {MaxLength} caracteres");

            RuleFor(x => x.DateBirth)
                .NotEmpty().WithMessage("'{PropertyName}' no puede ser vacío");

            RuleFor(x => x.Phone)
                .Matches(@"\(8[024]9\)[1-9][0-9]{2}-[0-9]{4}").WithMessage("'{PropertyName}' debe cumplir el formato: '(000)000-0000'")
                .MaximumLength(30).WithMessage("{PropertyName} no puede exceder {MaxLength} caracteres");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("'{PropertyName}' debe ser una dirección de correo eléctronico valído")
                .MaximumLength(50).WithMessage("{PropertyName} no puede exceder {MaxLength} caracteres");

            RuleFor(x => x.Address)
                .MaximumLength(50).WithMessage("{PropertyName} no puede exceder {MaxLength} caracteres");
        }
    }
}