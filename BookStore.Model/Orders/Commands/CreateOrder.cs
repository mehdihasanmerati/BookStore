using BookStore.Model.Frameworks;
using BookStore.Model.Orders.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Model.Orders.Commands
{
    public class CreateOrder: IRequest<ApplicationServiceResponse<Order>>
    {
        [Required]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [EmailAddress]
        public string CustomerEmail { get; set; }
    }
}
