using BookStore.BusinessLogic.Frameworks;
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
        private readonly IFileService _fileService;

        public BookController(IMediator mediator, IFileService fileService) : base(mediator)
        {
            _fileService = fileService;
        }

        private async Task LoadTagTaskAsync(UpdateBookViewModel model)
        {
            var tagReponce = await _mediator.Send(new GetTagQuery());
            if (tagReponce.IsSuccess)
            {
                model.TagsForDisplay = tagReponce.Result.Select(tag => new Tag
                {
                    Id = tag.Id,
                    TagName = tag.TagName,
                }).ToList();
            }
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
                    imageUrl = await _fileService.SaveImageAsync(model.ImageUrl);
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
                    return RedirectToAction("IndexBook");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            var bookResponse = await _mediator.Send(new GetBookByIdQuery { Id = id});

            if (bookResponse.IsSuccess)
            {
                var book = bookResponse.Result;

                var model = new UpdateBookViewModel
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Description = book.Description,
                    PublishDate = book.PublishDate,
                    Price = book.Price,
                    CurrentImageUrl = book.ImageUrl,
                    // انتخاب تگ‌هایی که در حال حاضر برای این کتاب تنظیم شده‌اند
                    SelectedTags = book.SelectedTags,

                };
                await LoadTagTaskAsync(model);
                return View(model);
            }
            return NotFound();  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBook(UpdateBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                await LoadTagTaskAsync(model);

                string imageUrl = model.CurrentImageUrl;
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    imageUrl = await _fileService.SaveImageAsync(model.ImageFile);
                }

                var command = new UpdateBook
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Author = model.Author,
                    Price = model.Price,
                    PublishDate = model.PublishDate,
                    ImageUrl = imageUrl, // مسیر ذخیره شده تصویر
                    ImageFile = model.ImageFile, // فایل اصلی تصویر از فرم
                    SelectedTags = model.SelectedTags,
                };
                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    return RedirectToAction("IndexBook");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var command = new DeleteBook { Id = id };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return RedirectToAction("IndexBook");
            }

            ModelState.AddModelError("", string.Join(" | ", result.Errors));
            return View();
        }
    }
}
