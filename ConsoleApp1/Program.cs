using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Bus> buses = new List<Bus>();

            start:
            while(true)
            {
                Console.WriteLine("Press Q to exit");
                var input = Console.ReadKey();

                if (input.Key == ConsoleKey.Q) {
                    break;
                }

                Console.WriteLine($"Bus Instance {Bus.GetNumberOfCreatedBuses() + 1} is to be created");
                Bus bus = new Bus();
                Console.WriteLine("Enter NumberLine :");
                bus.numberLine = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Starting :");
                bus.starting = Console.ReadLine();
                Console.WriteLine("Enter Ending :");
                bus.ending = Console.ReadLine();

                Console.WriteLine("Enter Garage");
                var g = Console.ReadKey();
                bus.garage = g.Key switch
                {
                    ConsoleKey.N => Garage.NASR,
                    ConsoleKey.F => Garage.FATEH,
                    ConsoleKey.A => Garage.AMIRIYAH,
                    ConsoleKey.G => Garage.GESR_SUEZ,
                    _ => Garage.OTHERS

                };

                buses.Add(bus);


            }


            while (true)
            {
                Console.WriteLine("Press Q to Exit");
                Console.WriteLine("Press P to Print Buses");
                Console.WriteLine("Press S to Save Buses into CSV");
                var input = Console.ReadKey();

                if (input.Key == ConsoleKey.Q)
                {
                    break;
                } else if (input.Key == ConsoleKey.P)
                {
                    if(buses.Count < 1)
                    {
                        Console.WriteLine("No buses Entered in list");
                        goto start;
                    }
                    foreach (var bus in buses)
                    {
                        Console.WriteLine("--------------------------");
                        bus.PrintInfo();
                    }
                } else if (input.Key == ConsoleKey.S)
                {
                    if (buses.Count < 1)
                    {
                        Console.WriteLine("No buses Entered in list");
                        goto start;
                    }

                    using (var writer = new StreamWriter("C:\\Users\\ahmed\\Documents\\Visual Studio 2022\\Projects\\Sol2\\buses.csv"))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<BusMap>();
                        csv.WriteRecords(buses);
                    }
                }
            }



        }
    }

}
