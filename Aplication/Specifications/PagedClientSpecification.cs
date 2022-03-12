using Ardalis.Specification;
using Domain.Entites;

namespace Application.Specifications
{
    public class PagedClientSpecification : Specification<Client>
    {
        public PagedClientSpecification(int pageNumber, int pageSize, string firstName, string lastName)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(firstName))
            {
                Query.Search(x => x.FirstName, $"%{firstName}%");
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                Query.Search(x => x.LastName, $"%{lastName}%");
            }
        }
    }
}