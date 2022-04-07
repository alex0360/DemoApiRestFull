using Application.Features.Clients.Commands;
using Application.Models;
using AutoMapper;
using Domain.Entites;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Model
            #region Client
            CreateMap<Client, ClientModel> ();
            #endregion
            #endregion

            #region Commands
            #region Client
            CreateMap<CreateClientCommand, Client>();
            #endregion
            #endregion
        }
    }
}