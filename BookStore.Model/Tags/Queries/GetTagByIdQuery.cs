using BookStore.Model.Frameworks;
using BookStore.Model.Tags.DTO;
using MediatR;

namespace BookStore.Model.Tags.Queries
{
    public class GetTagByIdQuery : IRequest<ApplicationServiceResponse<GetTagDto>>
    {
        public int Id { get; set; }
    }
}
