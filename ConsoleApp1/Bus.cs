using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum Garage
    {
        NASR,
        FATEH,
        GESR_SUEZ,
        AMIRIYAH,
        OTHERS


    }
    public class Bus
    {
        public const decimal Ticket = 6.0m;

        private static int numberOfCreatedBuses = 0;

        public int numberLine;

        public string starting;

        public string ending;

        public Garage garage;

        public int numberOfPassengers = 40;

        public Bus()
        {
            numberOfCreatedBuses++;
        }

        ~Bus()
        {
            numberOfCreatedBuses--;
        }

        private decimal CalculateIncome() => numberOfPassengers * Ticket;

        
        public void PrintInfo()
        {
            Console.WriteLine($"Bus {numberLine} {{ {starting} / {ending} }} , Garage {garage} gains EGP{CalculateIncome()}");
        }
        public static int GetNumberOfCreatedBuses()
        {
            return numberOfCreatedBuses;
        }
    }
}
