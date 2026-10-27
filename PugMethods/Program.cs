using System;

namespace PugMethods
{
    public delegate bool NumberCheck(int number);

    class Program
    {
        static void Main()
        {
            int[] pugNumbers = { 0, 1, 2, 3, 4, 5, 8, 9, 10, 13, 15, 21, 67 };

            Console.WriteLine("Массив pugNumbers: " + string.Join(", ", pugNumbers));
            Console.WriteLine();
            Console.WriteLine("Парные:     " + string.Join(", ", GetNumbers(pugNumbers, IsEven)));
            Console.WriteLine("Непарные:   " + string.Join(", ", GetNumbers(pugNumbers, IsOdd)));
            Console.WriteLine("Простые:    " + string.Join(", ", GetNumbers(pugNumbers, IsPrime)));
            Console.WriteLine("Фибоначчи: " + string.Join(", ", GetNumbers(pugNumbers, IsFibonacci)));
        }
        public static int[] GetNumbers(int[] numbers, NumberCheck check)
        {
            int count = 0;
            foreach (int num in numbers)
            {
                if (check(num))
                {
                    count++;
                }
            }
            int[] result = new int[count];
            int index = 0;
            foreach (int num in numbers)
            {
                if (check(num))
                {
                    result[index] = num;
                    index++;
                }
            }

            return result;
        }
        public static bool IsEven(int n) => n % 2 == 0;

        public static bool IsOdd(int n) => n % 2 != 0;

        public static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        public static bool IsFibonacci(int n)
        {
            if (n < 0) return false;

            int a = 0;
            int b = 1;

            while (a < n)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }

            return a == n;
        }
    }
}