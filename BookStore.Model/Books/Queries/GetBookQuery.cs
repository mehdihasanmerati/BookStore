using BookStore.Model.Books.DTO;
using BookStore.Model.Frameworks;
using MediatR;

namespace BookStore.Model.Books.Queries
{
    public class GetBookQuery: IRequest<ApplicationServiceResponse<List<GetBookDto>>>
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
