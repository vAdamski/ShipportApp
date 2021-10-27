using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipportApp.Application.Prospects.Queries.GetProspects;
using System.Threading.Tasks;

namespace ShipportApp.Controllers
{
    [Route("api/prospects")]
    [ApiController]
    public class ProspectsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetProspectsAsync()
        {
            var response = await Mediator.Send(new GetProspectsQuery { });

            return Ok(response);
        }
    }
}
