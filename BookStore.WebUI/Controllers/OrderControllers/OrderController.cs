using BookStore.Model.Books.Queries;
using BookStore.Model.Orders.Commands;
using BookStore.WebUI.Frameworks;
using BookStore.WebUI.Models.Orders;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BookStore.Model.Orders.Queries;
using BookStore.Model.Orders.DTO;

namespace BookStore.WebUI.Controllers.OrderControllers
{
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> IndexOrder(int bookId, string customerEmail)
        {
            var result = await _mediator.Send(new GetOrderQuery
            {
                BookId = bookId,
                CustomerEmail = customerEmail
            });

            if (result.IsSuccess)
            {
                return View(result.Result);
            }
            ModelState.AddModelError("", string.Join(", ", result.Errors));

            return View(new List<GetOrderDto>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var response = await _mediator.Send(new GetBookQuery());

            if (!response.IsSuccess)
            {
                ModelState.AddModelError("", "Unable access to the booklist!");
                return View();
            }

            var bookListItem = response.Result.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name,
            }).ToList();

            var viewModel = new CreateOrderViewModel
            {
                BookList = bookListItem
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new CreateOrder
                {
                    BookId = model.BookId,
                    OrderDate = model.OrderDate,
                    Price = model.Price,
                    CustomerEmail = model.CustomerEmail,
                };

                var result = await _mediator.Send(order);
                if (result.IsSuccess)
                {
                    return RedirectToAction("IndexOrder");
                }

                ModelState.AddModelError("", string.Join(", ", result.Errors));

                var books = await _mediator.Send(new GetBookQuery());
                model.BookList = books.Result.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name,
                }).ToList();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id, int bookId)
        {
            var orderResponse = await _mediator.Send(new GetOrderByIdQuery { Id = id, BookId = bookId });

            if (orderResponse.IsSuccess)
            {
                var result = orderResponse.Result;

                var order = new UpdateOrderViewModel
                {
                    BookId = result.BookId,
                    OrderDate = result.OrderDate,
                    Price = result.Price,
                    CustomerEmail = result.CustomerEmail,
                };
                return View(order);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new UpdateOrder
                {
                    Id = model.Id,
                    BookId = model.BookId,
                    OrderDate = model.OrderDate,
                    Price = model.Price,
                    CustomerEmail = model.CustomerEmail,
                };
                var result = await _mediator.Send(order);

                if (result.IsSuccess)
                {
                    return RedirectToAction("IndexOrder");
                }
                ModelState.AddModelError("", string.Join (", ", result.Errors));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _mediator.Send(new DeleteOrder { Id = id });

            if (order.IsSuccess)
            {
                return RedirectToAction("IndexOrder");
            }

            ModelState.AddModelError("", string.Join(", ", order.Errors));
            return View();
        }
    }
}
