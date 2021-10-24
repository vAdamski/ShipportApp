using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipportApp.Application.Rotations.Queries.GetRotation;
using ShipportApp.Domain.Entities;
using System.Threading.Tasks;

namespace ShipportApp.Controllers
{
    [Route("api/cargoes")]
    public class RotationController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<RotationVm>> GetAsync()
        {
            var terminals = await Mediator.Send(new GetRotationsQuery() { });

            return Ok(terminals);
        }
    }
}
