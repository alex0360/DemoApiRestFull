using Application.Interfaces;
using Application.Models;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Clients.Queries.GetAll
{
    public class GetClientAll : IRequest<PagedResponse<List<ClientModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public class GetClientAllHanlder : IRequestHandler<GetClientAll, PagedResponse<List<ClientModel>>>
        {
            private readonly IRepositoryAsync<Client> _repository;
            private readonly IMapper _mapper;

            public GetClientAllHanlder(IRepositoryAsync<Client> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PagedResponse<List<ClientModel>>> Handle(GetClientAll request, CancellationToken cancellationToken)
            {
                var clients = await _repository.ListAsync(new PagedClientSpecification(request.PageNumber, request.PageSize, request.FirstName, request.LastName));

                var clientsModel = _mapper.Map<List<ClientModel>>(clients);

                return new PagedResponse<List<ClientModel>>(clientsModel, request.PageNumber, request.PageSize);
            }
        }

    }
}