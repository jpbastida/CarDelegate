using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    class Car
    {
        public delegate void CarEngineHandler(string msgForCaller);

        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        private bool carIsDead;

        public Car()
        {
            MaxSpeed = 100;
        }

        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        // Define variable of the Delegate
        private CarEngineHandler listOfHandlers;

        // Registration functions for the caller
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers = methodToCall;
        }

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                if (listOfHandlers != null)
                {
                    listOfHandlers("You burned the car!");
                }
            }
            else
            {
                CurrentSpeed += delta;

                if ((MaxSpeed - CurrentSpeed) == 10 && listOfHandlers != null)
                {
                    listOfHandlers("Careful! Gonna blow!!!");
                }

                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine($"Current Speed = {CurrentSpeed}");
                }
            }
        }
    }
}
