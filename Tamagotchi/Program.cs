using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            Tamagotchi tama = new Tamagotchi();

            while(true)
            {
                Console.Clear();

                Console.WriteLine("Age: " + tama.Age.ToString());
                Console.WriteLine("Health: " + tama.Health.ToString());
                Console.WriteLine("Energy: " + tama.Energy.ToString());
                Console.WriteLine("Hunger: " + tama.Hunger.ToString());
                Console.WriteLine("Sleeping?: " + tama.IsSleeping.ToString());
                Console.WriteLine("Dead?: " + tama.IsDead.ToString());

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();

                    if (keyPressed.Key == ConsoleKey.F)
                        tama.Feed(25);
                }
            }
        }
    }
}
