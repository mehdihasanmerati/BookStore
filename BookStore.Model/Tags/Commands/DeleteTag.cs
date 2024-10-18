using BookStore.Model.Frameworks;
using MediatR;

namespace BookStore.Model.Tags.Commands
{
    public class DeleteTag: IRequest<ApplicationServiceResponse>
    {
        public int TagId { get; set; }
    }
}
