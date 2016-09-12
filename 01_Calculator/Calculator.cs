using System;
using System.Linq;

namespace _01_Calculator
{
    public class Calculator
    {
		public static int Add(int v1, int v2)
        {
            return v1 + v2;
        }

		public static int Subtract(int v1, int v2)
        {       
            return v1 - v2;
        }

		public static int Sum(int[] numbers)
        {
			return numbers.Sum();
        }

		public static int Multiply(int v1, int v2)
        {
            return v1 * v2;
        }

		public static int Power(double v1, double v2)
        {
			return (int)Math.Pow(v1, v2);
        }

		public static long Factorial(long v)
        {
            long sum = 1;
            for (long i = v; i > 0; i--)
            {
                sum *= i;
            }
            return sum;
        }

		internal static int Divide(int v1, int v2) {
			return v1 / v2;
		}
	}
}