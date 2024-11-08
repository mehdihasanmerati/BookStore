namespace BookStore.Model.Comments.DTO
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string BookComment { get; set; }
        public string CommentBy { get; set; }
        public bool IsValid { get; set; }
        public DateTime CommentDate { get; set; }
        public int BookId { get; set; }
    }
}
