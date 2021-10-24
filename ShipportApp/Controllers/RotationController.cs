using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipportApp.Application.Rotations.Queries.GetRotation;
using ShipportApp.Domain.Entities;
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
            RotationVm rotation = await Mediator.Send(new GetRotationsQuery { });

            Console.WriteLine(rotation.ToString());

            //if(rotation == null)
            //{
            //    return NotFound();
            //}

            return Ok(rotation);
        }
    }
}
