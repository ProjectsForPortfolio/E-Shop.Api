using System.Threading.Tasks;
using e_Shop.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController: ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok(typeof(VersionController).Assembly.GetName().Version?.ToString());
        }
    }
}