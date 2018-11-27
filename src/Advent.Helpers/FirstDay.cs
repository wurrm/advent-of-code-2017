using System;

namespace Advent.Helpers
{
    public static class Conversion
    {
        public static int CharToInt(char c)
        {
            return (int)char.GetNumericValue(c);
        }
    }
}
