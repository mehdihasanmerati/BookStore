using BookStore.Model.Frameworks;
using MediatR;

namespace BookStore.Model.Comments.Commands
{
    public class DeleteComment: IRequest<ApplicationServiceResponse<bool>>
    {
        public int Id { get; set; }
    }
}
