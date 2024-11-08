using BookStore.Model.Authors.DTO;
using BookStore.Model.Frameworks;
using MediatR;

namespace BookStore.Model.Authors.Queries
{
    public class GetAuthorByIdQuery: IRequest<ApplicationServiceResponse<GetAuthorDto>>
    {
        public int Id { get; set; }
    }
}
