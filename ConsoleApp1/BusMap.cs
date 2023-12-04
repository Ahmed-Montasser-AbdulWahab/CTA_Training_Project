using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BusMap : ClassMap<Bus>
    {
        public BusMap()
        {

            Map(m => m.numberLine).Index(0).Name("NumberLine");
            Map(m => m.starting).Index(1).Name("Starting");
            Map(m => m.ending).Index(2).Name("Ending");
            Map(m => m.garage).Index(3).Name("Garage");

        }
    }
}
