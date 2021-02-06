using System.Collections.Generic;
using System.Threading.Tasks;
using E_Shop.Api.Domain.Models;
using E_Shop.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return Ok(await productService.Get());
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            return Ok(await productService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            var id = await productService.Create(product);

            return CreatedAtRoute("GetProduct", new { id = id }, product);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult> Update(string id, Product product)
        {
            var item = await productService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            await productService.Update(id, product);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> Delete(string id)
        {
            var book = await productService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            await productService.Delete(id);
            return NoContent();
        }
    }
}
