using System;

namespace App
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");
        }
        public static double Formula(double value) {
            double result = (9 / (value + 4));
            if (Double.IsNaN(result)) {
                throw new Exception("Extracting the square root from a negative number");
            }
            return result;
        }
    }
}
