using BookStore.Model.Authors.Entities;
using BookStore.Model.Frameworks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Model.Authors.Commands
{
    public class UpdateAuthor: IRequest<ApplicationServiceResponse<Author>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
