using Application.Interfaces;
using Application.Models;
using Application.Wrappers;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Clients.Queries.GetById
{
    public class GetClientById : IRequest<Response<ClientModel>>
    {
        public int Id { get; set; }
        public class GetClientByIdHandler : IRequestHandler<GetClientById, Response<ClientModel>>
        {
            private readonly IRepositoryAsync<Client> _repository;
            private readonly IMapper _mapper;

            public GetClientByIdHandler(IRepositoryAsync<Client> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Response<ClientModel>> Handle(GetClientById request, CancellationToken cancellationToken)
            {
                var client = await _repository.GetByIdAsync(request.Id);

                if (client == null)
                    throw new KeyNotFoundException($"Registro no encontrado con le Id: {request.Id}");

                var clientModel = _mapper.Map<ClientModel>(client);

                return new Response<ClientModel>(clientModel);
            }
        }
    }
}