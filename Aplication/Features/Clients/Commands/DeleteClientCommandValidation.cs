using FluentValidation;

namespace Application.Features.Clients.Commands
{
    public class DeleteClientCommandValidation : AbstractValidator<CreateClientCommand>
    {
        public DeleteClientCommandValidation()
        {

        }
    }
}