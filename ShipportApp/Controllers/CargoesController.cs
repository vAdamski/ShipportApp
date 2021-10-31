using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipportApp.Application.Cargoes.Commands.CreateCargo;
using ShipportApp.Application.Cargoes.Commands.DeleteCargo;
using ShipportApp.Application.Cargoes.Queries.GetCargoes;
using ShipportApp.Domain.Entities;
using System.Threading.Tasks;

namespace ShipportApp.Controllers
{
    [Route("api/cargoes")]
    public class CargoesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CargoesVm>> GetAsync()
        {
            var cargoesVm = await Mediator.Send(new GetCargoesQuery { });

            if (cargoesVm == null)
            {
                return NotFound();
            }

            return Ok(cargoesVm);
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostAsync([FromBody] CreateCargoCommand cargo)
        {
            var id = await Mediator.Send(cargo);

            if(id == null)
            {
                return BadRequest();
            }

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteCargo(string id)
        {
            if (id == null)
            {
                return BadRequest(id);
            }

            await Mediator.Send(new DeleteCargoCommand() { CargoId = id });

            return Ok();
        }
    }
}
