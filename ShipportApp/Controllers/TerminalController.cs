using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipportApp.Application.Common.Interfaces;
using ShipportApp.Application.Terminals.Queries.GetTerminal;
using ShipportApp.Application.Terminals.Queries.GetTerminals;
using ShipportApp.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ShipportApp.Controllers
{
    [Route("api/terminals")]
    public class TerminalController : BaseController
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
