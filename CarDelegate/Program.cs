using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Delegates as event enablers ****");

            Car car = new Car("Jaguar", 100, 10);

            car.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            Console.WriteLine("*** Speeding UP!!! ***");
            for (int i = 0; i < 6; i++)
            {
                car.Accelerate(20);
            }
        }

        private static void OnCarEngineEvent(string msgForCaller)
        {
            Console.WriteLine("\n **** Message from Car Object ****");
            Console.WriteLine($"=> {msgForCaller}");
            Console.WriteLine("*******************************\n ");
        }
    }
}
