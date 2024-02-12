using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMCinema.AppService.Common;

namespace SMCinema.WebApi.Common
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BaseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        protected async Task<IActionResult> Handle<TData>(dynamic data)
        {
            if (data is null)
                return BadRequest();

            var result = new HandlerResult<TData>();
            if (ModelState.IsValid)
            {
                try
                {
                    result.Data = await _mediator.Send(data);
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Messages.Add(ex.Message);
                }
            }
            else
            {
                result.Messages = ModelState.Values.SelectMany(m => m.Errors)
                                                   .Select(e => e.ErrorMessage)
                                                   .ToList();
            }

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
