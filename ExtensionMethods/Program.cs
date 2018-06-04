using System;

namespace ExtensionMethods
{
    // 
    // Методы расширения действуют на уровне пространства имен
    // 

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string s = Console.ReadLine();

            Console.Write("Введите символ, который нужно найти: ");
            char c = Convert.ToChar(Console.ReadLine());

            int i = s.WordCount(c);
            Console.WriteLine($"Количество символов в строке: {i}");

            Console.ReadLine();
        }
    }

    public static class StringExtension
    {
        public static int WordCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }

            return counter;
        }
    }
}
