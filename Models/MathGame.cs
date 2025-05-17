using MathGameConsoleApp.Utilities.Enums;
using MathGameConsoleApp.Utilities.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameConsoleApp.Models
{
    internal class MathGame
    {
        private static readonly int _questionsCount = 10;
        private static int _count;
        private Question[] _questions = new Question[_questionsCount];

        private static MathGame[] _gamesHistory = new MathGame[0];

        public int Id { get; set; }
        public GameModeEnum Mode { get; set; }

        public int CorrectAnswersCount { get; set; }
        public int IncorrectAnswersCount { get; set; }
        public double GameDurationSeconds { get; set; }

        public MathGame()
        {
            _count++;
            Id = _count;
            SelectGameMode();
            GenerateQuestions();
            StartResolve();
        }

        private void StartResolve()
        {
            int count = 1;
            DateTime startTime = DateTime.Now;
            foreach (Question question in _questions)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Question #{count}/10:");
                Console.WriteLine("-----------------------");
                Console.ResetColor();
                Console.WriteLine(question.DisplayName);
                int result = Helper.GetValidNumber(int.MinValue, int.MaxValue,"Choice",false);
                if (result == question.Result)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Good, it is correct!");
                    Console.ResetColor();
                    CorrectAnswersCount++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Oops, incorrect answer! The correct answer is {question.Result}");
                    Console.ResetColor();
                    IncorrectAnswersCount++;
                }
                count++;
            }
            DateTime endTime = DateTime.Now;
            GameDurationSeconds = (endTime - startTime).TotalSeconds;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Game is over! Your result: {CorrectAnswersCount}/10, Duration: {GameDurationSeconds}s");
            Console.ResetColor();
            Array.Resize(ref _gamesHistory, _gamesHistory.Length + 1);
            _gamesHistory[^1] = this;
            
        }
        private void GenerateQuestions()
        {
            for (int i = 0; i < _questions.Length; i++)
            {
                _questions[i] = new Question(Mode);
            }
        }
      
        private void SelectGameMode()
        {
            Console.WriteLine("Please, select a mode:");
            Console.WriteLine("-----------------------");
            int counter = 1;
            foreach (GameModeEnum val in Enum.GetValues(typeof(GameModeEnum)))
            {
                Console.WriteLine($"{counter}. {val}");
                counter++;
            }
            int choice = Helper.GetValidNumber(1, 3);
            Mode = (GameModeEnum) choice;

        }

        public static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("MENU:\n------------------\n1. Start new game \n2. Find game by ID \n3. Show fastest game \n4. Exit \n------------------");
            Console.ResetColor();
        }

        public static MathGame? FindGameById(int id)
        {
            for (int i = 0; i < _gamesHistory.Length; i++)
            {
                if (_gamesHistory[i].Id == id) return _gamesHistory[i];
            }
            return null;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Mode: {Mode}, GameDuration: {GameDurationSeconds}s, Result: {CorrectAnswersCount}/10";
        }
    }
}
