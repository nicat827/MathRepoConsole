using MathGameConsoleApp.Utilities.Enums;
using MathGameConsoleApp.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameConsoleApp.Models
{
    internal class Question
    {
        private static readonly int _operatorsCount = GetOperatorsCount();
        public string DisplayName { get; set; }
        public float Result { get; set; }

        public Question(GameModeEnum mode)
        {
            int maxNum = GetMaxNum(mode);
            int firstNum = Helper.GetRandomNum(1, maxNum);
            int secondNum = Helper.GetRandomNum(1, maxNum);
            int randomOperator = Helper.GetRandomNum(1, _operatorsCount);


            DisplayName = $"{firstNum} {Enum.GetName(typeof(OperatorTypeEnum),randomOperator)} {secondNum}";
            Result = GetQuestionResult(firstNum, secondNum, randomOperator);
        }

        private float GetQuestionResult(int a, int b, int operatorNum)
        {
            float res;
            switch (operatorNum)
            {
                case (int)OperatorTypeEnum.Plus:
                    res = a + b;
                    break;
                case (int)OperatorTypeEnum.Minus:
                    res = a - b;
                    break;
                case (int)OperatorTypeEnum.Divide:
                    res = a / b;
                    break;
                case (int)OperatorTypeEnum.Multiply:
                    res = a * b;
                    break;
                default:
                    throw new Exception("Operator tapılmadı!");
            };
            return res;
        }

        private static int GetOperatorsCount()
        {
            int operatorsCount = 0;
            foreach (OperatorTypeEnum type in Enum.GetValues(typeof(OperatorTypeEnum)))
            {
                operatorsCount++;
            }
            return operatorsCount;
        }
        private int GetMaxNum(GameModeEnum mode)
        {
            int maxNum;
            switch (mode)
            {
                case GameModeEnum.Easy:
                    maxNum = 9;
                    break;
                case GameModeEnum.Medium:
                    maxNum = 15;
                    break;
                case GameModeEnum.Hard:
                    maxNum = 18;
                    break;
                default:
                    maxNum = 9;
                    break;
            }
            return maxNum;
        }
       
    }
}
