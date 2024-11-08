using BookStore.Model.Frameworks;
using MediatR;

namespace BookStore.Model.Books.Commands
{
    public class DeleteBook: IRequest<ApplicationServiceResponse<bool>>
    {
        public int Id { get; set; }
    }
}
