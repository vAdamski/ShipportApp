using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipportApp.Application.Rotations.Commands.EditRotation;
using ShipportApp.Application.Rotations.Queries.GetRotation;
using System;
using System.Threading.Tasks;

namespace ShipportApp.Controllers
{
    [Route("api/rotation")]
    public class RotationController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<RotationVm>> GetAsync()
        {
            var rotation = await Mediator.Send(new GetRotationsQuery { });

            if (rotation == null)
            {
                return NotFound();
            }

            return Ok(rotation);
        }

        [HttpPatch]
        public async Task<ActionResult<RotationVm>> PatchAsync([FromBody] EditRotationVm rotation)
        {
            var newRotation = await Mediator.Send(new EditRotationCommand { EditRotationVm = rotation });

            return Ok(newRotation);
        }
    }
}
