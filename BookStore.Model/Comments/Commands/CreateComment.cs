using BookStore.Model.Comments.Entities;
using BookStore.Model.Frameworks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Model.Comments.Commands
{
    public class CreateComment: IRequest<ApplicationServiceResponse<Comment>>
    {
        [Required]
        [StringLength(100)]
        public string BookComment { get; set; }

        [Required]
        [StringLength(100)]
        public string CommentBy { get; set; }

        [Required(ErrorMessage = "Please choose the comment is valid or not")]
        public bool IsValid { get; set; }

        [DataType(DataType.Date)]
        public DateTime CommentDate { get; set; }

        [Required]
        public int BookId { get; set; }
    }
}
