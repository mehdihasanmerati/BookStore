using BookStore.Model.Books.Entities;
using BookStore.Model.Frameworks;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Model.Books.Commands
{
    public class UpdateBook: IRequest<ApplicationServiceResponse<Book>>
    {
        [Required]
        [Range(1, int.MaxValue)]    
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Author { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } // مسیر تصویر ذخیره شده
        public IFormFile ImageFile { get; set; } // برای دریافت فایل ورودی از فرم
        public List<int> SelectedTags { get; set; } = new List<int>();

    }
}
