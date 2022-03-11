using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Clients.Commands
{
    public class CreateClientCommand : IRequest<Response<int>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }        
    }

    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Client> _repository;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IRepositoryAsync<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Client>(request);

            var data = await _repository.AddAsync(record, cancellationToken);

            return new Response<int>(data.Id);
        }
    }
}