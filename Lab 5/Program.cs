using System;
using System.Threading;

class Program
{
    static int[] array = new int[18];
    static readonly object lockObj = new object();

    static void Main(string[] args)
    {
        Random random = new Random();

        // Заповнення масиву випадковими числами в проміжку від 0 до 90
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(0, 91); // Випадкове число від 0 до 90
        }

        // Потік 1: виведення квадратів всіх елементів
        Thread thread1 = new Thread(new ThreadStart(DisplaySquares));
        thread1.Start();

        // Потік 2: виведення чисел менше 50
        Thread thread2 = new Thread(new ThreadStart(DisplayNumbersLessThan50));
        thread2.Start();
    }

    static void DisplaySquares()
    {
        lock (lockObj)
        {
            Console.WriteLine("Квадрати всіх елементів:");
            foreach (var number in array)
            {
                Console.WriteLine($"Квадрат {number} = {number * number}");
            }
        }
    }

    static void DisplayNumbersLessThan50()
    {
        lock (lockObj)
        {
            Console.WriteLine("Числа менше 50:");
            foreach (var number in array)
            {
                if (number < 50)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
