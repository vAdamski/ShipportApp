using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipportApp.Application.Terminals.Queries.GetTerminal;
using ShipportApp.Application.Terminals.Queries.GetTerminals;
using System.Threading.Tasks;

namespace ShipportApp.Controllers
{
    [Route("api/terminals")]
    public class TerminalsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<TerminalsVm>> GetAsync()
        {
            var terminals = await Mediator.Send(new GetTerminalsQuery() { });

            return Ok(terminals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TerminalVm>> GetByIdAsync(string id)
        {
            var terminal = await Mediator.Send(new GetTerminalQuery() { TerminalId = id });

            return Ok(terminal);
        }
    }
}
