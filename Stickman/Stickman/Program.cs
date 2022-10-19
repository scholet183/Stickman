using System;
using System.Windows;

namespace Stickman
{
    class Program
    {
        static void Main()
        {
            var stickman1 = new Stickman("Harry");
            int counter = 0;
            double timefactor = 1.0;
            int stamina;
            String msg = " C - Chill\n W - Walk \n R - Run \n Spacebar - Reset\n\n Press Enter to Start";
            Console.TreatControlCAsInput = true;
            Console.WriteLine(msg);
            Console.ReadKey();
            while (true)
            {
                Console.Clear();
                stamina = Stickman.handling(counter, stickman1.CurrentState);
                if (stamina == 0) 
                { 
                    stickman1.TakeAction(Stickman.Action.Exhaust);
                }
                if (Console.KeyAvailable)
                {
                    var cki = Console.ReadKey();
                    switch (cki.Key)
                    {
                        case ConsoleKey.C:
                            stickman1.TakeAction(Stickman.Action.Chill);
                            timefactor = 1.0;
                            break;
                        case ConsoleKey.W:
                            stickman1.TakeAction(Stickman.Action.Walk);
                            timefactor = 1.0;
                            break;
                        case ConsoleKey.R:
                            stickman1.TakeAction(Stickman.Action.Run);
                            timefactor = 2.5;
                            break;
                        case ConsoleKey.Spacebar:
                            stickman1.TakeAction(Stickman.Action.Chill);
                            timefactor = 1.0;
                            Stickman.space = " ";
                            Stickman.stamina = 20;
                            break;
                    }
                }
                counter++;
                Thread.Sleep(Convert.ToInt16(1000/timefactor));
            }
        }
    }
}
