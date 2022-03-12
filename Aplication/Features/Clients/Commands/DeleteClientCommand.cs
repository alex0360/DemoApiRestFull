using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Clients.Commands
{
    public class DeleteClientCommand : IRequest<Response<int>>
    {
        public int Id { get; set; } 
    }

    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Client> _repository;
        private readonly IMapper _mapper;

        public DeleteClientCommandHandler(IRepositoryAsync<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var recordClient =  await _repository.GetByIdAsync(request.Id);

            if (recordClient == null)
                throw new KeyNotFoundException($"Registro no encontrado con le Id: {request.Id}");

            await _repository.DeleteAsync(recordClient);

            return new Response<int>(recordClient.Id);
        }
    }
}