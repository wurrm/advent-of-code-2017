using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Advent.Second
{
    class Program
    {
        static void Main()
        {
            StreamReader f = new StreamReader("input.txt");

            string row;
            List<int> row_checksums = new List<int>();

            while ((row = f.ReadLine()) != null)
            {
                int[] pRow = Array.ConvertAll<string, int>(Regex.Split(row, @"\s+"), int.Parse);
                row_checksums.Add(CalculateRowChecksum(pRow));
            }

            Console.WriteLine(row_checksums.Sum());
        }

        static int CalculateRowChecksum(int[] row)
        {
            return (row.Max() - row.Min());
        }
    }
}
