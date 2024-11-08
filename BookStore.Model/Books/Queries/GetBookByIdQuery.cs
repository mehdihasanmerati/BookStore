using BookStore.Model.Books.DTO;
using BookStore.Model.Frameworks;
using MediatR;

namespace BookStore.Model.Books.Queries
{
    // ساختن این command  برای [HttpGet] UpdateBook 
    public class GetBookByIdQuery: IRequest<ApplicationServiceResponse<GetBookDto>>
    {
        public int Id { get; set; }
    }
}
