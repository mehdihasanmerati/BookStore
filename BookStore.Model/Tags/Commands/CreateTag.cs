using BookStore.Model.Frameworks;
using BookStore.Model.Tags.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Model.Tags.Commands
{
    public class CreateTag: IRequest<ApplicationServiceResponse<Tag>>
    {
        // validation
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string TagName { get; set; }

    }
}
