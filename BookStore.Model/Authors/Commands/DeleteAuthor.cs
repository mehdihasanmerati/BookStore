using BookStore.Model.Frameworks;
using MediatR;

namespace BookStore.Model.Authors.Commands
{
    public class DeleteAuthor: IRequest<ApplicationServiceResponse<bool>>
    {
        public int Id { get; set; }
    }
}
