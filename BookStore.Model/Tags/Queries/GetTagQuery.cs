using BookStore.Model.Frameworks;
using BookStore.Model.Tags.DTO;
using MediatR;

namespace BookStore.Model.Tags.Queries
{
    public class GetTagQuery: IRequest<ApplicationServiceResponse<List<GetTagDto>>>
    {
        public string? TagName { get; set; }
    }
}
