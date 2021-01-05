using System.Collections.Generic;
using System.Threading.Tasks;
using e_Shop.Application;
using E_Shop.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return Ok(await mediator.Send(new ProductQuery()));
        }
    }
}