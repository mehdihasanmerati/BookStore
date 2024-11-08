using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.WebUI.Models.Comments
{
    public class CreateCommentViewModel
    {
        public int Id { get; set; }
        public string BookComment { get; set; }
        public string CommentBy { get; set; }
        public bool IsValid { get; set; }
        public DateTime CommentDate { get; set; }
        public int BookId { get; set; } 

        public List<SelectListItem> BookList { get; set; } = new List<SelectListItem>();
    }

}
