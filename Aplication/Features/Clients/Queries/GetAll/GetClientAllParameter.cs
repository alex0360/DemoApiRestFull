using Application.Parameters;

namespace Application.Features.Clients.Queries.GetAll
{
    public class GetClientAllParameter : RequestParameter
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}