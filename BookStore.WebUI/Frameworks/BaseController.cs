﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Frameworks
{
    public abstract class BaseController: Controller
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
