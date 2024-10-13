using System.ComponentModel.DataAnnotations;

namespace BookStore.Model.Tags.Commands
{
    // کلاس DTO  که حاوی اطلاعاتی است که می توانیم انتیتی خودمان را ثبت کنیم
    // یعنی حاوی اطلاعات یوزر است که بتوانیم آن را ثبت کنیم مثل update , delete, add  و در کل CQRS
    // آبجکت کامند در مدل قرار می گیرد و هندلر کامند در بیزینس لاجیک قرار می گیرد
    public class CreateTag
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string TagName { get; set; }

    }
}
