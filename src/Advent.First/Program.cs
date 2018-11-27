using System;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            int output = RecurseReverseCaptcha(args[0], CharToInt(args[0][args[0].Length - 1]), 0);
            Console.WriteLine(output);
        }

        static int CharToInt(char c)
        {
            return (int)char.GetNumericValue(c);
        }

        // Tail recursion because reverse sounds like recurse
        static int RecurseReverseCaptcha(string input, int prevDigit, int repeatSum)
        {
            int currDigit = CharToInt(input[0]);

            if (input.Length == 1)
            {
                return repeatSum;
            }
            else if (currDigit == prevDigit)
            {
                repeatSum += currDigit;
            }

            return RecurseReverseCaptcha(input.Substring(1, input.Length - 1), currDigit, repeatSum);
        }
    }
}
