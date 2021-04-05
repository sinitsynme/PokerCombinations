using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1.View
{
    public class ViewCount
    {
        static void Design()
        {
            for (int i = 0; i < 81; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
        
        /// <summary>
        /// Prints cards by their code
        /// </summary>
        /// <param name="s">Card's code in a library</param>

        public static void Out(int[] s, Dictionary<int, string> cards) //выводит карты
        {
            foreach (int key in s)
            {
                Console.Write(cards[key] + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Prints probability info
        /// </summary>
        public static void PrintInfo(Stopwatch time, Dictionary<string, int> combinations, int count)
        {
            Design();
            Console.WriteLine("--------ПРОГРАММА ДЛЯ ПОДСЧЕТА ЧИСЛА КОМБИНАЦИЙ В ПОКЕРЕ И ИХ ВЕРОЯТНОСТИ--------");
            Design();
            Console.WriteLine($"{"Комбинация", 25} | {"Число комбинаций", 25} | {"Вероятность выпадения, %", 25}");
            Design();
            Console.WriteLine($"{"Старшая карта", 25} | {combinations["Старшая карта"], 25} | {(double) combinations["Старшая карта"]/count*100, 25}");
            Design();
            Console.WriteLine($"{"Пара", 25} | {combinations["Пара"], 25} | {(double) combinations["Пара"]/count*100, 25}");
            Design();
            Console.WriteLine($"{"Две пары", 25} | {combinations["Две пары"], 25} | {(double) combinations["Две пары"]/count*100, 25}");
            Design();
            Console.WriteLine($"{"Сет", 25} | {combinations["Сет"], 25} | {(double) combinations["Сет"]/count*100, 25}");
            Design();
            Console.WriteLine($"{"Стрит", 25} | {combinations["Стрит"], 25} | {(double) combinations["Стрит"]/count*100, 25}");
            Design();
            Console.WriteLine($"{"Флеш", 25} | {combinations["Флеш"], 25} | {(double) combinations["Флеш"]/count*100, 25}");
            Design();
            Console.WriteLine($"{"Фул-Хаус", 25} | {combinations["Фулхаус"], 25} | {(double) combinations["Фулхаус"]/count*100, 25}");
            Design();
            Console.WriteLine($"{"Каре", 25} | {combinations["Каре"], 25} | {(double) combinations["Каре"]/count*100, 25}");
            Design();
            Console.WriteLine($"{"Стрит-Флеш", 25} | {combinations["Стрит-Флеш"], 25} | {(double) combinations["Стрит-Флеш"]/count*100, 25}");
            Design();
            Console.WriteLine($"{"Флеш-Рояль", 25} | {combinations["Роял-Флеш"], 25} | {(double) combinations["Роял-Флеш"]/count*100, 25}");
            Design();
            Console.WriteLine("Число всех сочетаний: " + count);
            Design();
            Console.WriteLine("Время работы программы: " + time.Elapsed);
            Console.ReadLine();
        }
    }
}