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

            // There was a comment here about how using a step and creating a general solution would be over-engineering the problem.
            // There was another about the general recursive implementation being a pain, so I shouldn't bother.
            // They are gone now.
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

            return RecurseReverseCaptcha(input, step, index + 1, repeatSum);
        }

        // The above solution is a valid general algorithm, and semantically all efficient solutions are O(n)
        // Logically though, part 2 can have the number of elements checked halved, as the sequence of indices is repeated in the second half of the computation
        // This simple heuristic is shown iteratively below
        static int HalfReverseCaptcha(string input)
        {

            int half = input.Length / 2;
            int sum = 0;

            for (int i = 0; i < half; i++)
            {
                if (input[i] == input[i + half])
                    sum += (int)char.GetNumericValue(input[i]);
            }

            // See how this kid made O(n) -> O(n/2) in one simple trick. CS undergrads HATE him!
            return sum * 2;
        }
    }
}
