using BookStore.Model.Books.Entities;
using BookStore.Model.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Comments.Entities
{
    public class Comment : BaseEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string BookComment { get; set; }
        public string CommentBy { get; set; }
        public bool IsValid { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
