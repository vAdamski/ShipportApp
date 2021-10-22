using System;

namespace ShipportApp.Application.Cargoes.Queries.GetCargoes
{
    public class CargoDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TerminalId { get; set; }
        public DateTime? ATC { get; set; }
    }
}