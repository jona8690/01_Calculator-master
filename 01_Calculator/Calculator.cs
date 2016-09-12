using System;

namespace _01_Calculator
{
    internal class Calculator
    {
        internal static int Add(int v1, int v2)
        {
            int sum;
            sum = v1 + v2;
            return sum;
        }

        internal static int Subtract(int v1, int v2)
        {
            int difference;
            difference = v1 - v2;
            return difference;
        }

        internal static int Sum(int[] numbers)
        {
            int sum = 0;
            foreach(int x in numbers)
            {
                sum += x;
            }
            return sum;
        }

        internal static int Multiply(int v1, int v2)
        {
            int total;
            total = v1 * v2;
            return total;
        }

        internal static int Power(double v1, double v2)
        {
            return (int)Math.Pow(v1, v2);
        }

        internal static long Factorial(long v)
        {
            long sum = 1;
            for (long i = v; i > 0; i--)
            {
                sum *= i;
            }
            return sum;
        }
    }
}