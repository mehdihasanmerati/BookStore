using BookStore.Model.Authors.Commands;
using BookStore.Model.Authors.DTO;
using BookStore.Model.Authors.Queries;
using BookStore.WebUI.Frameworks;
using BookStore.WebUI.Models.Authors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers.AuthorControllers
{
    public class AuthorController : BaseController
    {
        public AuthorController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> IndexAuthor()
        {
            var result = await _mediator.Send(new GetAuthorQuery());
            if (result.IsSuccess)
            {
                return View(result.Result);
            }
            ModelState.AddModelError("", string.Join(", ", result.Errors));
            return View(new List<GetAuthorDto>());
        }

        [HttpGet]
        public IActionResult CreateAuthor()
        {
            var model = new CreateAuthorViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = new CreateAuthor
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

                var result = await _mediator.Send(author);

                if (result.IsSuccess)
                {
                    return RedirectToAction("IndexAuthor");
                }

                ModelState.AddModelError("", string.Join(", ", result.Errors)); 
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var authorResponse = await _mediator.Send(new GetAuthorByIdQuery { Id = id });

            if (authorResponse.IsSuccess)
            {
                var result = authorResponse.Result;

                var author = new UpdateAuthorViewModel
                {
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                };
                return View(author); 
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = new UpdateAuthor
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

                var result = await _mediator.Send(author);

                if (result.IsSuccess)
                {
                    return RedirectToAction("IndexAuthor");
                }

                ModelState.AddModelError("", string.Join (", ", result.Errors));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _mediator.Send(new DeleteAuthor { Id = id });

            if (author.IsSuccess)
            {
                return RedirectToAction(nameof(IndexAuthor));
            }
            ModelState.AddModelError("", string.Join(", ", author.Errors));
            return View(author);
        }
        
    }
}
