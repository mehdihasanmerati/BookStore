using BookStore.Model.Tags.Commands;
using BookStore.WebUI.Frameworks;
using BookStore.WebUI.Models.Tags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStore.WebUI.Controllers.TagControllers
{
    public class TagController : BaseController
    {
        public TagController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public IActionResult CreateTag()
        {
            var model = new CreateTagViewModel();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateTag { TagName = model.TagName };
                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }

                model.Errors.AddRange(result.Errors);
            }

            return View(model); 
        }
        
    }
}
