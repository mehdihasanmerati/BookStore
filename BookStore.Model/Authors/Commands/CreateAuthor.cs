using BookStore.Model.Authors.Entities;
using BookStore.Model.Frameworks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Model.Authors.Commands
{
    public class CreateAuthor: IRequest<ApplicationServiceResponse<Author>>
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
