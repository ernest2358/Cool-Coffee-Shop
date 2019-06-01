using System;
using System.Collections.Generic;
using System.Text;

namespace Cool_Coffee_Shop
{
    public static class Common
    {
        public static int GetInt(int min, int max)
        {
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                {
                    return result;
                }
                Console.Write($"Input error. Please enter an integer between {min} and {max}");
            }
        }
        public static bool KeepGoing(string question)
        {
            Console.Write($"{question} ");
            while (true)
            {
                var input = Console.ReadLine().ToLower();
                if (input == "y") return true;
                if (input == "n") return false;
                Console.Write("Input error. Please enter y or n: ");
            }
        }

    }
}
