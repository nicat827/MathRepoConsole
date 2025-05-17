using MathGameConsoleApp.Models;
using MathGameConsoleApp.Utilities.Extensions;

namespace MathGameConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mainChoice = 0;
            while (mainChoice != 4)
            {
                MathGame.ShowMenu();
                mainChoice = Helper.GetValidNumber(1, 4);

                switch (mainChoice)
                {
                    case 1:
                        MathGame newGame =new MathGame();
                        break;
                    case 2:
                        int id = Helper.GetValidNumber(1, int.MaxValue, "Enter ID");
                        MathGame game = MathGame.FindGameById(id);
                        if (game is null)
                        {
                            Console.WriteLine("Game not found!");
                        }
                        else
                        {
                            Console.WriteLine("Finded Game:");
                            Console.WriteLine(game);
                        }
                        break;
                }


            }
            Console.WriteLine("Program dayandı");
        }

       

       

        
    }
}
