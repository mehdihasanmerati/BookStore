using BookStore.Model.Comments.Entities;
using BookStore.Model.Frameworks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Model.Comments.Commands
{
    public class UpdateComment: IRequest<ApplicationServiceResponse<Comment>>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [StringLength(100)]
        public string BookComment { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string CommentBy { get; set; }

        [Required(ErrorMessage = "Please choose the comment is valid or not")]
        public bool IsValid { get; set; }

        [DataType(DataType.Date)]
        public DateTime CommentDate { get; set; }

        [Required]
        public int BookId { get; set; }

    }
}
