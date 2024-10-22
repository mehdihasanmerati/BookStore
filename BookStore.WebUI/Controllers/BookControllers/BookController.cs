using BookStore.Model.Books.Commands;
using BookStore.Model.Books.DTO;
using BookStore.Model.Books.Entities;
using BookStore.Model.Books.Queries;
using BookStore.Model.Tags.Entities;
using BookStore.Model.Tags.Queries;
using BookStore.WebUI.Frameworks;
using BookStore.WebUI.Models.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers.BookControllers
{
    public class BookController : BaseController
    {
        public BookController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> IndexBook()
        {
            var query = new GetBookQuery();
            var result = await _mediator.Send(query);

            if (result.IsSuccess)
            {
                return View(result.Result);
            }
            ModelState.AddModelError("", string.Join(", ", result.Errors));
            return View(new List<GetBookDto>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateBook()
        {
            var response = await _mediator.Send(new GetTagQuery());
            
            if(response.IsSuccess)
            {
                var tagsForDesplay = response.Result.Select(tagDto => new Tag
                {
                    Id = tagDto.Id,
                    TagName = tagDto.TagName,
                }).ToList();

                var model = new CreateBookViewModel
                {
                    TagsForDisplay = tagsForDesplay
                };
                return View(model);
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                string imageUrl = null;
               
                if (model.ImageUrl != null && model.ImageUrl.Length > 0) 
                {
                    var fileName = Path.GetFileName(model.ImageUrl.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", model.ImageUrl.FileName);

                    using(var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageUrl.CopyToAsync(stream);
                    }

                    imageUrl = "/images/" + fileName;
                }

                var command = new CreateBook
                {
                    Name = model.Name,
                    Author = model.Author,
                    Description = model.Description,
                    PublishDate = model.PublishDate,
                    Price = model.Price,
                    ImageUrl = imageUrl,
                    BookTags = model.SelectedTags.Select(c => new BookTag
                    {
                        TagId = c
                    }).ToList()
                };

                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
