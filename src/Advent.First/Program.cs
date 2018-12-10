using System;

namespace Advent.First
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Please specify the number of the part you want to solve (1 or 2) followed by your input.");
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
                    output = RecurseReverseCaptcha(input, 1, 0, 0);
                    break;
                case "2":
                    // Part 2
                    if (input.Length % 2 != 0)
                    {
                        Console.WriteLine("Please provide an input with an even number of digits.");
                        return -1;
                    }
                    output = RecurseReverseCaptcha(input, input.Length / 2, 0, 0);
                    break;
                default:
                    return 1;
            }
            Console.WriteLine(output);
            return 0;
        }

        // Tail recursion because reverse sounds like recurse, and tails since we don't want to vomit calls when we do the actual puzzle input
        static int RecurseReverseCaptcha(string input, int step, int index, int repeatSum)
        {
            char currDigit = input[index];
            char nextDigit = input[(index + step) % input.Length];

            if (currDigit == nextDigit)
                repeatSum += (int)char.GetNumericValue(currDigit);

            if (index == input.Length - 1)
                return repeatSum;

            index++;

            return RecurseReverseCaptcha(input, step, index, repeatSum);
        }

        // Not recursion because punting around indexes as args would be a pain and creating our own wrapper etc. seems annoying
        static int HalfReverseCaptcha(string input)
        {

            int half = input.Length / 2;
            int sum = 0;

            for (int i = 0; i < half; i++)
            {
                if (input[i] == input[i + half])
                    sum += (int)char.GetNumericValue(input[i]);
            }

            // Learn how this kid make O(n) -> O(n/2) in one simple trick. CS undergrads HATE him!
            return sum * 2;
        }
    }
}
