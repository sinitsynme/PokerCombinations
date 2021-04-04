﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        
        private static Dictionary<int, string> _cards = new Dictionary<int, string>();

        private static Dictionary<int, string> _suits = new Dictionary<int, string>()
        {
            [0] = "♠", [1] = "♥", [2] = "♦", [3] = "♣"
        };

        private static Dictionary<string, int> _combinations = new Dictionary<string, int>()
        {
            ["Пара"] = 0, ["Сет"] = 0, ["Две пары"] = 0, ["Стрит"] = 0, ["Флеш"] = 0, ["Фулхаус"] = 0,
            ["Каре"] = 0, ["Стрит-Флеш"] = 0, ["Роял-Флеш"] = 0, ["Старшая карта"] = 0
        };
        

        private static string[] _values = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        
        private static int _count = 0; //считает подходящие сочетания
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //даёт вывести символы крестушек/пикушек...
            CreateCards();
            /*foreach (var card in _cards.Values)
            {
                Console.WriteLine(card);
            }

            Console.ReadLine();*/

            int[] fiveCards = new int[5]; //для ключей карт, вошедших в сочетание

            Rec(0,0,ref fiveCards);
            PrintInfo();
            
        }

        /// <summary>
        /// Recursive brute force
        /// </summary>
        /// <param name="idx">First index</param>
        /// <param name="last">Last index</param>
        /// <param name="fiveCards">Combination array</param>
        static void Rec(int idx, int last, ref int[] fiveCards)
        {
            if (idx == 5)
            {
                if (Test(fiveCards))
                {
                    _count++;
                    // Out(fiveCards); // включить для вывода комбинаций в консоль
                }
                return;
            }

            for (int i = last + 1; i <= 52;i++)
            {
                fiveCards[idx] = i;
                Rec(idx+1, i, ref fiveCards);
                
            }
            
        } 
        
        /// <summary>
        /// Fills library of cards
        /// </summary>
        static void CreateCards()
        {
            /*
                
                ---СПИСОК КЛЮЧЕЙ И КАРТ---
                
                key - value
                1 - 2♥
                2 - 2♦
                3 - 2♣
                4 - 2♠
                5 - 3♥
                6 - 3♦    
                7 - 3♣
                8 - 3♠
                9 - 4♥
                10 - 4♦
                11 - 4♣
                12 - 4♠
                13 - 5♥
                14 - 5♦
                15 - 5♣
                16 - 5♠
                17 - 6♥
                18 - 6♦
                19 - 6♣
                20 - 6♠    
                21 - 7♥
                22 - 7♦
                23 - 7♣
                24 - 7♠
                25 - 8♥ 
                26 - 8♦ 
                27 - 8♣ 
                28 - 8♠ 
                29 - 9♥
                30 - 9♦
                31 - 9♣
                32 - 9♠
                33 - 10♥ 
                34 - 10♦ 
                35 - 10♣ 
                36 - 10♠ 
                37 - J♥ 
                38 - J♦ 
                39 - J♣ 
                40 - J♠ 
                41 - Q♥ 
                42 - Q♦ 
                43 - Q♣ 
                44 - Q♠ 
                45 - K♥ 
                46 - K♦ 
                47 - K♣ 
                48 - K♠ 
                49 - A♥ 
                50 - A♦ 
                51 - A♣ 
                52 - A♠ 
            */
            
            int count = 1;
            for (int i = 1; i <= 13; i++)
            {
                string s;
                if (i > 0 && i < 10)
                {
                    s = (i + 1).ToString();
                }

                else if (i == 10)
                {
                    s = "J";
                }

                else if (i == 11)
                {
                    s = "Q";
                }

                else if (i == 12)
                {
                    s = "K";
                }
                else
                {
                    s = "A";
                }
                
                _cards.Add(count++, s+"♥");
                _cards.Add(count++, s+"♦");
                _cards.Add(count++, s+"♣");
                _cards.Add(count++, s+"♠");
                
            }
        }
        /// <summary>
        /// Prints cards by their code
        /// </summary>
        /// <param name="s">Card's code in a library</param>

        static void Out(int[] s) //выводит карты
        {
            foreach (int key in s)
            {
                Console.Write(_cards[key] + " ");
            }
            Console.WriteLine();
        }
        static string Suit(int key)
        {
            return _suits[key % 4];
        }

        static string Value(int key)
        {
            return _values[(key-1) / 4];
        }
        
        /// <summary>
        /// Tests 5 cards and defines the combination
        /// </summary>
        /// <param name="fiveCards">Sample of 5 cards</param>
        /// <returns></returns>
        static bool Test(int[] fiveCards)
        {
            int[] suits = new int[4];
            int[] values = new int[13];


            foreach (int key in fiveCards)
            {
                suits[key % 4]++;
                values[(key - 1) / 4]++;
            }
            
            if (Combinations.IsRoyalFlush(values, suits))
            {
                _combinations["Роял-Флеш"]++;
                return true;
            }
            if (Combinations.IsStraightFlush(values, suits))
            {
                _combinations["Стрит-Флеш"]++;
                return true;
            }
            
            if (Combinations.IsFourOfAKind(values))
            {
                _combinations["Каре"]++;
                return true;
            }
            
           
            if (Combinations.IsFullHouse(values))
            {
                _combinations["Фулхаус"]++;
                return true;
            }
            
            if (Combinations.IsFlush(suits))
            {
                _combinations["Флеш"]++;
                return true;
            }
            if (Combinations.IsStraight(values))
            {
                _combinations["Стрит"]++;
                return true;
            }
            
            if (Combinations.IsSet(values))
            {
                _combinations["Сет"]++;
                return true;
            }
            
            if (Combinations.IsTwoPairs(values))
            {
                _combinations["Две пары"]++;
                return true;
            }
            
            if (Combinations.IsPair(values))
            {
                _combinations["Пара"]++;
                return true;
            }
            
            _combinations["Старшая карта"]++;
            return true;
            
            
            /* ВЫВОД НА ЭКРАН МАССИВОВ ЗНАЧЕНИЙ И МАСТЕЙ
            foreach (int i in suits)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            foreach (int i in values)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();*/

        }

        static void Design()
        {
            for (int i = 0; i < 81; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Prints probability info
        /// </summary>
        static void PrintInfo()
        {
            Design();
            Console.WriteLine("--------ПРОГРАММА ДЛЯ ПОДСЧЕТА ЧИСЛА КОМБИНАЦИЙ В ПОКЕРЕ И ИХ ВЕРОЯТНОСТИ--------");
            Design();
            Console.WriteLine($"{"Комбинация", 25} | {"Число комбинаций", 25} | {"Вероятность выпадения, %", 25}");
            Design();
            Console.WriteLine($"{"Старшая карта", 25} | {_combinations["Старшая карта"], 25} | {(double) _combinations["Старшая карта"]/_count*100, 25}");
            Design();
            Console.WriteLine($"{"Пара", 25} | {_combinations["Пара"], 25} | {(double) _combinations["Пара"]/_count*100, 25}");
            Design();
            Console.WriteLine($"{"Две пары", 25} | {_combinations["Две пары"], 25} | {(double) _combinations["Две пары"]/_count*100, 25}");
            Design();
            Console.WriteLine($"{"Сет", 25} | {_combinations["Сет"], 25} | {(double) _combinations["Сет"]/_count*100, 25}");
            Design();
            Console.WriteLine($"{"Стрит", 25} | {_combinations["Стрит"], 25} | {(double) _combinations["Стрит"]/_count*100, 25}");
            Design();
            Console.WriteLine($"{"Флеш", 25} | {_combinations["Флеш"], 25} | {(double) _combinations["Флеш"]/_count*100, 25}");
            Design();
            Console.WriteLine($"{"Фул-Хаус", 25} | {_combinations["Фулхаус"], 25} | {(double) _combinations["Фулхаус"]/_count*100, 25}");
            Design();
            Console.WriteLine($"{"Каре", 25} | {_combinations["Каре"], 25} | {(double) _combinations["Каре"]/_count*100, 25}");
            Design();
            Console.WriteLine($"{"Стрит-Флеш", 25} | {_combinations["Стрит-Флеш"], 25} | {(double) _combinations["Стрит-Флеш"]/_count*100, 25}");
            Design();
            Console.WriteLine($"{"Флеш-Рояль", 25} | {_combinations["Роял-Флеш"], 25} | {(double) _combinations["Роял-Флеш"]/_count*100, 25}");
            Design();
            Console.WriteLine("Число всех сочетаний равно " + _count);
            Console.ReadLine();
        }

    }
}