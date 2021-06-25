using System;
using System.Runtime.InteropServices;
using Mastermind.Core;

namespace Mastermind.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
                                 .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .-----------------. .----------------. 
                                | .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |
                                | | ____    ____ | || |      __      | || |    _______   | || |  _________   | || |  _________   | || |  _______     | || | ____    ____ | || |     _____    | || | ____  _____  | || |  ________    | |
                                | ||_   \  /   _|| || |     /  \     | || |   /  ___  |  | || | |  _   _  |  | || | |_   ___  |  | || | |_   __ \    | || ||_   \  /   _|| || |    |_   _|   | || ||_   \|_   _| | || | |_   ___ `.  | |
                                | |  |   \/   |  | || |    / /\ \    | || |  |  (__ \_|  | || | |_/ | | \_|  | || |   | |_  \_|  | || |   | |__) |   | || |  |   \/   |  | || |      | |     | || |  |   \ | |   | || |   | |   `. \ | |
                                | |  | |\  /| |  | || |   / ____ \   | || |   '.___`-.   | || |     | |      | || |   |  _|  _   | || |   |  __ /    | || |  | |\  /| |  | || |      | |     | || |  | |\ \| |   | || |   | |    | | | |
                                | | _| |_\/_| |_ | || | _/ /    \ \_ | || |  |`\____) |  | || |    _| |_     | || |  _| |___/ |  | || |  _| |  \ \_  | || | _| |_\/_| |_ | || |     _| |_    | || | _| |_\   |_  | || |  _| |___.' / | |
                                | ||_____||_____|| || ||____|  |____|| || |  |_______.'  | || |   |_____|    | || | |_________|  | || | |____| |___| | || ||_____||_____|| || |    |_____|   | || ||_____|\____| | || | |________.'  | |
                                | |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | |
                                | '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |
                                 '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' 
                                ");

            
            Core.Mastermind mastermind = new Core.Mastermind();
 
            Console.WriteLine("Please enter the amount of colors you want to use ? Or press enter to use default game settings (6)");
            if(int.TryParse(Console.ReadLine(), out var result)) mastermind.ColorsAmount = result;
            
            Console.WriteLine("PLease enter row lenght ? Or press enter to use default game settings (4)");
            if(int.TryParse(Console.ReadLine(), out  result)) mastermind.ColorsAmount = result;
            
            Console.WriteLine("Please enter a game lenght ? Or press enter to use default game settings (9)");
            if(int.TryParse(Console.ReadLine(), out  result)) mastermind.ColorsAmount = result;
            
            Print(mastermind);
        }

        private static void Print(Core.Mastermind mastermind)
        {
            for (int i = 0; i < mastermind.GameLenght; i++)
            {
                for (int j = 0; j < mastermind.RowLength; j++)
                {
                    Console.Write(" - ");
                }

                Console.WriteLine("\t");

                Console.WriteLine();
            }
        }
    }
}