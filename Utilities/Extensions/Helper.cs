using MathGameConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameConsoleApp.Utilities.Extensions
{
    internal static class Helper
    {
        public static int GetValidNumber(int minLength, int maxLength, string inpText = "Choice", bool clearConsole = true)
        {
            int res;
            bool isSuccess;
            do
            {
                Console.Write($"{inpText}: ");
                isSuccess = int.TryParse(Console.ReadLine(), out res);
                if (clearConsole) ClearConsole();

                if (isSuccess)
                {
                    if (res < minLength || res > maxLength) isSuccess = false;
                }
                if (!isSuccess)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice, please try again");
                    Console.ResetColor();
                }
            }
            while (!isSuccess);
            return res;
        }

        public static void ClearConsole()
        {
            Console.Clear();
            MathGame.ShowMenu();
        }

        public static int GetRandomNum(int minNum, int maxNum)
        {
            Random random = new Random();
            return random.Next(minNum, maxNum);
        }
    }
}
