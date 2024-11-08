using BookStore.Model.Comments.DTO;
using BookStore.Model.Frameworks;
using MediatR;

namespace BookStore.Model.Comments.Queries
{
    public class GetCommentByIdQuery: IRequest<ApplicationServiceResponse<GetCommentDto>>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
    }
}
