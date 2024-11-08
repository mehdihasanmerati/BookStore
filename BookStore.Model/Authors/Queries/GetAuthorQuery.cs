using BookStore.Model.Authors.DTO;
using BookStore.Model.Frameworks;
using MediatR;

namespace BookStore.Model.Authors.Queries
{
    public class GetAuthorQuery: IRequest<ApplicationServiceResponse<List<GetAuthorDto>>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
