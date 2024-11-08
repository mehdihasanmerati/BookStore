using BookStore.Model.Tags.Commands;
using BookStore.Model.Tags.DTO;
using BookStore.Model.Tags.Queries;
using BookStore.WebUI.Frameworks;
using BookStore.WebUI.Models.Tags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers.TagControllers
{
    public class TagController : BaseController
    {
        public TagController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> IndexTag()
        {
            var query = new GetTagQuery();
            var result = await _mediator.Send(query);

            if (result.IsSuccess)
            {
                return View(result.Result);
            }

            ModelState.AddModelError("", string.Join(", ", result.Errors));
            return View(new List<GetTagDto>()); 
        }

        [HttpGet]
        public IActionResult CreateTag()
        {
            var model = new CreateTagViewModel();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTag(CreateTagViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateTag
                {
                    TagName = model.TagName
                };
                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    return RedirectToAction("IndexTag");
                }

                ModelState.AddModelError("", string.Join(", ", result.Errors));
            }

            return View(model); 
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTag(int id)
        {
           var tagResponse = await _mediator.Send(new GetTagByIdQuery { Id = id });

            if (tagResponse.IsSuccess)
            {
                var result = tagResponse.Result;

                var model = new UpdateTagViewModel
                {
                    TagId = result.Id,
                    TagName = result.TagName,
                };
                return View(model);
            }
            return NotFound();
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTag(UpdateTagViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new UpdateTag
                {
                    Id = model.TagId,
                    TagName = model.TagName,
                };

                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    return RedirectToAction("IndexTag");
                }

                ModelState.AddModelError("", string.Join(", ", result.Errors)); 
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> DeleteTag(int id)
        {
            var command = new DeleteTag { TagId = id };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return RedirectToAction("IndexTag");
            }

            ModelState.AddModelError("", string.Join(", ", result.Errors));

            return RedirectToAction("IndexTag");
        }
    }
}
