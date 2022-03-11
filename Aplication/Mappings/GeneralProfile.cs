using Application.Features.Clients.Commands;
using AutoMapper;
using Domain.Entites;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands
                CreateMap<CreateClientCommand, Client>();
            #endregion
        }
    }
}