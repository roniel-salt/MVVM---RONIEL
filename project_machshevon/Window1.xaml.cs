using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace project_machshevon
{
    internal class GameLogic
    {
        public static (string, string, string, string,string,string) GenerateQuestion(int Age, int questionsRemaining)
        {
            Random random = new Random();
            int num1 = random.Next(1, 11);
            int num2 = random.Next(1, 11);
            int real_answer = 0;
            string text1 = "";
            string text2 = "";
            string mathSign = "";
            string remaining = "";

            if (Age >= 8)
            {
                int operation;
                if (questionsRemaining >= 6)
                {
                    operation = random.Next(3, 5);
                }
                else
                {
                    operation = random.Next(1, 3);
                }

                Console.WriteLine($"Selected operation: {operation}");

                switch (operation)
                {
                    case 1:
                        text1 = num1.ToString();
                        text2 = num2.ToString();
                        mathSign = "+";
                        real_answer = num1 + num2;
                        break;
                    case 2:
                        text1 = num1.ToString();
                        text2 = num2.ToString();
                        mathSign = "-";
                        real_answer = num1 - num2;
                        break;
                    case 3:
                        text1 = num1.ToString();
                        text2 = num2.ToString();
                        mathSign = "*";
                        real_answer = num1 * num2;
                        break;
                    case 4:
                        text1 = (num1 * num2).ToString();
                        text2 = num2.ToString();
                        mathSign = "/";
                        real_answer = num1;
                        break;
                }
            }
            else if (Age >= 6)
            {
                int operation;
                if (questionsRemaining <= 3)
                {
                    operation = 2;
                }
                else
                {
                    operation = random.Next(1, 3);
                }

                Console.WriteLine($"Selected operation: {operation}");

                switch (operation)
                {
                    case 1:
                        text1 = num1.ToString();
                        text2 = num2.ToString();
                        mathSign = "+";
                        real_answer = num1 + num2;
                        break;
                    case 2:
                        text1 = num1.ToString();
                        text2 = num2.ToString();
                        mathSign = "-";
                        real_answer = num1 - num2;
                        break;
                    case 3:
                        text1 = num1.ToString();
                        text2 = num2.ToString();
                        mathSign = "*";
                        real_answer = num1 * num2;
                        break;
                }
            }
            else
            {
                int operation = random.Next(1, 2);
                Console.WriteLine($"Selected operation: {operation}");

                switch (operation)
                {
                    case 1:
                        text1 = num1.ToString();
                        text2 = num2.ToString();
                        mathSign = "+";
                        real_answer = num1 + num2;
                        break;
                    case 2:
                        text1 = num1.ToString();
                        text2 = num2.ToString();
                        mathSign = "-";
                        real_answer = num1 - num2;
                        break;
                }
            }
            string real = real_answer.ToString();
            remaining = $"Questions remaining: {questionsRemaining}";
            string questions = questionsRemaining.ToString();
            return (text1, text2, mathSign, remaining,real,questions);
        }

    }
}
