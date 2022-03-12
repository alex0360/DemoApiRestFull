using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Clients.Commands
{
    public class UpdateClientCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }        
    }

    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Client> _repository;
        private readonly IMapper _mapper;

        public UpdateClientCommandHandler(IRepositoryAsync<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var recordClient =  await _repository.GetByIdAsync(request.Id);

            if (recordClient == null)
                throw new KeyNotFoundException($"Registro no encontrado con le Id: {request.Id}");

            recordClient.FirstName = request.FirstName;
            recordClient.LastName = request.LastName;
            recordClient.DateBirth = request.DateBirth;
            recordClient.Phone = request.Phone;
            recordClient.Email = request.Email;
            recordClient.Address = request.Address;

            await _repository.UpdateAsync(recordClient);

            return new Response<int>(recordClient.Id);
        }
    }
}