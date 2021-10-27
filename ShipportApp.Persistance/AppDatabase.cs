using ShipportApp.Application.Common.Interfaces;
using ShipportApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipportApp.Persistance
{
    public class AppDatabase : IAppDatabase
    {
        public List<Cargo> cargos { get; set; }
        public List<Terminal> terminals { get; set; }

        public AppDatabase()
        {
            InitalizeTerminal();
            InitailizeCargoes();
        }

        private void InitailizeCargoes()
        {
            cargos = new List<Cargo>
            {
                new Cargo()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Books",
                    TerminalId = "0175d159-f61f-40b9-aaf7-967dbe461349",
                    ATC = DateTime.Now,
                },
                new Cargo()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Notebooks",
                    TerminalId = "0175d159-f61f-40b9-aaf7-967dbe461349",
                    ATC = DateTime.Now,
                },

                //Second Terminal
                new Cargo()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "GPU's",
                    TerminalId = "02ec54f7-8a50-454f-9503-62eeb2f3f4d0",
                    ATC = DateTime.Now,
                },
                new Cargo()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Power Banks",
                    TerminalId = "02ec54f7-8a50-454f-9503-62eeb2f3f4d0",
                    ATC = DateTime.Now,
                },

                //Third Terminal
                new Cargo()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Car parts",
                    TerminalId = "035d8512-1093-4e40-bc90-d677d059a380",
                    ATC = DateTime.Now,
                },
                new Cargo()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Apples",
                    TerminalId = "035d8512-1093-4e40-bc90-d677d059a380",
                    ATC = DateTime.Now,
                }
            };
        }

        private void InitalizeTerminal()
        {
            terminals = new List<Terminal>();

            terminals.Add(
                new Terminal()
                {
                    Id = "0175d159-f61f-40b9-aaf7-967dbe461349",
                    Name = "FirstTerminal"
                });
            terminals.Add(
                new Terminal()
                {
                    Id = "02ec54f7-8a50-454f-9503-62eeb2f3f4d0",
                    Name = "SecondTerminal"
                });
            terminals.Add(
                new Terminal()
                {
                    Id = "035d8512-1093-4e40-bc90-d677d059a380",
                    Name = "ThirdTerminal"
                });
        }
    }
}
