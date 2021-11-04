using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipportApp.Application.Prospects.QueriesV2.GetProspects;
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
            var response = await Mediator.Send(new GetProspectQuery { });

            return Ok(response);
        }
    }
}
