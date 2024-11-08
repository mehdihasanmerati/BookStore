using BookStore.Model.Comments.DTO;
using BookStore.Model.Frameworks;
using MediatR;

namespace BookStore.Model.Comments.Queries
{
    public class GetCommentQuery: IRequest<ApplicationServiceResponse<List<GetCommentDto>>>
    {
        public string BookComment { get; set; }
        public string CommentBy { get; set; }
        public bool IsValid { get; set; }
        public DateTime CommentDate { get; set; }
        public int BookId { get; set; }
    }
}
