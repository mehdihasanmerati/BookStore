using BookStore.Model.Books.Queries;
using BookStore.Model.Comments.Commands;
using BookStore.Model.Comments.DTO;
using BookStore.Model.Comments.Queries;
using BookStore.WebUI.Frameworks;
using BookStore.WebUI.Models.Comments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.WebUI.Controllers.CommentControllers
{
    public class CommentController : BaseController
    {
        public CommentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> IndexComment()
        {
            var result = await _mediator.Send(new GetCommentQuery());
            if (result.IsSuccess)
            {
                return View(result.Result);
            }

            ModelState.AddModelError("", string.Join(", ", result.Errors)); 
            return View(new List<GetCommentDto>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateComment()
        {
            // Request to receive a list of books
            var response = await _mediator.Send(new GetBookQuery());

            if (!response.IsSuccess)
            {
                ModelState.AddModelError("", "Unable access to the booklist!");
                return View();
            }

            // Creating the SelectListItem list to display in the dropdown
            var bookListItems = response.Result.Select( b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name,
            }).ToList();

            // Create a ViewModel with a list of books
            var viewModel = new CreateCommentViewModel
            {
                BookList = bookListItems
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateComment
                {
                    BookComment = model.BookComment,
                    CommentBy = model.CommentBy,
                    IsValid = model.IsValid,
                    CommentDate = model.CommentDate,
                    BookId = model.BookId
                };

                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    return RedirectToAction("IndexComment");
                }

                ModelState.AddModelError("", string.Join(", ", result.Errors));
            }

            // Reset to booklist in case of error
            var books = await _mediator.Send(new GetBookQuery());
            model.BookList = books.Result.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            }).ToList();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateComment(int id, int bookId)
        {
            var commentResponse = await _mediator.Send(new GetCommentByIdQuery { Id = id , BookId = bookId });

            if (commentResponse.IsSuccess)
            {
                var result = commentResponse.Result;

                var comment = new UpdateCommentViewModel
                {
                    BookComment = result.BookComment,
                    CommentBy = result.CommentBy,
                    IsValid = result.IsValid,
                    CommentDate = result.CommentDate,
                    BookId= result.BookId
                };
                return View(comment);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentViewModel model)
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
                var command = new UpdateComment
                {
                    Id = model.Id,
                    BookComment = model.BookComment,
                    CommentBy = model.CommentBy,
                    IsValid = model.IsValid,
                    CommentDate = model.CommentDate,
                    BookId = model.BookId
                };
               var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    return RedirectToAction("IndexComment");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = new DeleteComment{Id = id};
            var result = await _mediator.Send(comment);

            if (result.IsSuccess)
            {
                return RedirectToAction("IndexComment");
            }

            ModelState.AddModelError("", string.Join(", ", result.Errors));
            return View();
        }
    }
}
