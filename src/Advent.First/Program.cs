using System;

using Advent.Helpers;

namespace Advent.First
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Please specify the number of the part you want to solve followed by your input.");
                return 1;
            }

            string input = args[1];
            int output;

            // Ideally we'd implement a general solution that takes a "step" as an argument, so we can do however far ahead in the list we please (part 2)
            // But that would be dumb because why would you over-engineer it that much
            switch (args[0])
            {
                case "1":
                    // Part 1
                    // Only circular aspect needed in this case is checking first digit against last, so we can do it for free here
                    output = RecurseReverseCaptcha(input, input[input.Length - 1], 0);
                    break;
                case "2":
                    // Part 2
                    output = HalfReverseCaptcha(input);
                    break;
                default:
                    return 1;
            }
            Console.WriteLine(output);
            return 0;
        }

        // Tail recursion because reverse sounds like recurse, and we don't want to vomit calls when we do puzzle input
        static int RecurseReverseCaptcha(string input, char prevDigit, int repeatSum)
        {
            char currDigit = input[0];

            if (currDigit == prevDigit)
                repeatSum += Conversion.CharToInt(currDigit);

            if (input.Length == 1)
                return repeatSum;

            return RecurseReverseCaptcha(input.Substring(1, input.Length - 1), currDigit, repeatSum);
        }

        // Not recursion because punting around indexes as args would be a pain and creating our own wrapper etc. seems annoying
        static int HalfReverseCaptcha(string input)
        {
            if (input.Length % 2 != 0)
            {
                Console.WriteLine("Please provide an input with an even number of digits.");
                return -1;
            }

            int half = input.Length / 2;
            int sum = 0;

            for (int i = 0; i < half; i++)
            {
                if (input[i] == input[i + half])
                    sum += Conversion.CharToInt(input[i]);
            }

            // Learn how this kid make O(n) -> O(n/2) in one simple trick. CS undergrads HATE him!
            return sum * 2;
        }
    }
}
