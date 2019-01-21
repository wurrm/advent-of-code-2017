using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Advent.Second
{
    class Program
    {
        public delegate int CalculateRow(int[] row);

        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please specify the number of the part you want to solve (1 or 2).");
                return 1;
            }

            // Set function to execute to what user asks for
            CalculateRow fn;
            switch (args[0])
            {
                case "1":
                    fn = CalculateRowChecksum;
                    break;
                case "2":
                    fn = CalculateRowDivisor;
                    break;
                default:
                    return 1;
            }

            StreamReader f = new StreamReader("input.txt");

            string row;
            List<int> row_checksums = new List<int>();

            // Iterate over rows, obtaining a value from given function on the row
            while ((row = f.ReadLine()) != null)
            {
                int[] pRow = Array.ConvertAll<string, int>(Regex.Split(row, @"\s+"), int.Parse);
                row_checksums.Add(fn(pRow));
            }

            // Output answer
            Console.WriteLine(row_checksums.Sum());
            return 0;
        }

        static int CalculateRowChecksum(int[] row)
        {
            // Defined as difference between largest and smallest value in row
            return (row.Max() - row.Min());
        }

        static int CalculateRowDivisor(int[] row)
        {
            // Definied as result of only even division in row

            int remainder;
            // Exhuastively test all pairs of values in row
            for (int i = 0; i < row.Length; i++)
            {
                for (int j = i + 1; j < row.Length; j++)
                {
                    remainder = (row[i] < row[j]) ? row[j] % row[i] : row[i] % row[j];
                    if (row[i] % row[j] == 0)
                        return row[i] / row[j];
                    else if (row[j] % row[i] == 0)
                        return row[j] / row[i];
                }
            }

            // TODO add exception should this code be reached
            return 0;
        }
    }
}
