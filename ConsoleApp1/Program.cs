using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {

        //создал словарь, подробнее в методе CreateCards
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
        
        private static int count = 0; //считает подходящие сочетания
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //даёт вывести символы крестушек/пикушек...
            CreateCards(ref _cards);
            /*foreach (var card in _cards.Values)
            {
                Console.WriteLine(card);
            }

            Console.ReadLine();*/

            int[] fiveCards = new int[5]; //для ключей карт, вошедших в сочетание

            Rec(0,0,ref fiveCards);
            PrintInfo();
            
        }


        static void Rec(int idx, int last, ref int[] fiveCards)
        {
            if (idx == 5)
            {
                if (Test(fiveCards))
                {
                    count++;
                    // Out(fiveCards, _cards); //вывод комбинаций в консоль
                    //Console.ReadLine();
                }
                return;
            }

            for (int i = last + 1; i <= 52;i++)
            {
                fiveCards[idx] = i;
                Rec(idx+1, i, ref fiveCards);
                
            }
            
        } //рекурсивный перебор - не трогаем!!!
        

        static void CreateCards(ref Dictionary<int, string> cards)
        {
            /*
                Ребятки, этот метод не трогаем, он нам генерирует библиотеку всех существующих
                36 карт. 
                Библиотека - структура данных, которая хранит в себе данные в виде
                таких пар, как "ключ-значение". По ключу из словаря мы можем доставать значения, обращаемся как к массиву
                К примеру, вызвав команду cards[1] мы получим 6♥, cards[2] нам выдаст 6♦ и так далее.
                
                ---СПИСОК КЛЮЧЕЙ И КАРТ---
                
                key - value
                1 - 2♥
                2 - 2♦
                3 - 2♣
                4 - 2♠
                5 - 3♥
                6 - 3♦    (cards[6] выведет 7♦)...
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
                20 - 6♠    (cards[20] выведет 10♠)...
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
                
                !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                определить масть по ключу:
                метод Suit(int key)
                
                определить достоинство карты по ключу:
                метод Value(int key)
                
                
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
                
                cards.Add(count++, s+"♥");
                cards.Add(count++, s+"♦");
                cards.Add(count++, s+"♣");
                cards.Add(count++, s+"♠");
                
            }
        }

        static void Out(int[] s, Dictionary<int, string> cards) //выводит карты
        {
            foreach (int key in s)
            {
                Console.Write(cards[key] + " ");
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
        
        //Нужно переписать под себя только метод Test()!
        //-------------------------------------------------------------------------------
        /*ПРИМЕР АЛГОРИТМА
         12 вар -  Нужно, чтобы ТОЧНО были 2 дамы, 2 туза, 1 карта пиковой масти
         то есть надо проверить массив ключей на то, что у нас есть 2 непиковых дамы, 2 непиковых туза 
         и 1 пикушка
        */
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
                //Console.WriteLine("Флеш-Рояль");
                _combinations["Роял-Флеш"]++;
                return true;
            }
            if (Combinations.IsStraightFlush(values, suits))
            {
                //Console.WriteLine("Стрит-Флеш");
                _combinations["Стрит-Флеш"]++;
                return true;
            }
            
            if (Combinations.IsFourOfAKind(values))
            {
                //Console.WriteLine("Каре");
                _combinations["Каре"]++;
                return true;
            }
            
           
            if (Combinations.IsFullHouse(values))
            {
                //Console.WriteLine("Фулхаус");
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
                //Console.WriteLine("Стрит");
                _combinations["Стрит"]++;
                return true;
            }
            
            if (Combinations.IsSet(values))
            {
                //Console.WriteLine("Сет");
                _combinations["Сет"]++;
                return true;
            }
            
            if (Combinations.IsTwoPairs(values))
            {
                //Console.WriteLine("Две пары");
                _combinations["Две пары"]++;
                return true;
            }
            
            if (Combinations.IsPair(values))
            {
                //Console.WriteLine("Пара");
                _combinations["Пара"]++;
                return true;
            }
            
            _combinations["Старшая карта"]++;
            return true;
            
            //ВЫВОД НА ЭКРАН ЧИСЛА КАРТ
/*
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

        public static void PrintInfo()
        {
            Console.WriteLine("Число комбинаций 'СТАРШАЯ КАРТА' равно " + _combinations["Старшая карта"] + ", вероятность выпадения: " + (double) _combinations["Старшая карта"]/count*100 +
                              ", шанс встретить в 1 из " + (double) count/_combinations["Старшая карта"]);
            Console.WriteLine();
            Console.WriteLine("Число комбинаций 'ПАРА' равно " + _combinations["Пара"] + ", вероятность выпадения: " + (double) _combinations["Пара"]/count*100 +
                              ", шанс встретить в 1 из " + (double) count/_combinations["Пара"]);
            Console.WriteLine();
            Console.WriteLine("Число комбинаций 'ДВЕ ПАРЫ' равно " + _combinations["Две пары"] + ", вероятность выпадения: " + (double) _combinations["Две пары"]/count*100 +
                              ", шанс встретить в 1 из " + (double) count/_combinations["Две пары"]);
            Console.WriteLine();
            Console.WriteLine("Число комбинаций 'СЕТ' равно " + _combinations["Сет"] + ", вероятность выпадения: " + (double) _combinations["Сет"]/count*100 +
                              ", шанс встретить в 1 из " + (double) count/_combinations["Сет"]);
            Console.WriteLine();
            Console.WriteLine("Число комбинаций 'СТРИТ' равно " + _combinations["Стрит"] + ", вероятность выпадения: " + (double) _combinations["Стрит"]/count*100 +
                              ", шанс встретить в 1 из " + (double) count/_combinations["Стрит"]);
            Console.WriteLine();
            Console.WriteLine("Число комбинаций 'ФЛЕШ' равно " + _combinations["Флеш"] + ", вероятность выпадения: " + (double) _combinations["Флеш"]/count*100 + 
                              ", шанс встретить в 1 из " + (double) count/_combinations["Флеш"]);
            Console.WriteLine();
            Console.WriteLine("Число комбинаций 'ФУЛ-ХАУС' равно " + _combinations["Фулхаус"] + ", вероятность выпадения: " + (double) _combinations["Фулхаус"]/count*100 +
                              ", шанс встретить в 1 из " + (double) count/_combinations["Фулхаус"]);
            Console.WriteLine();
            Console.WriteLine("Число комбинаций 'КАРЕ' равно " + _combinations["Каре"] + ", вероятность выпадения: " + (double) _combinations["Каре"]/count*100 +
                              ", шанс встретить в 1 из " + (double) count/_combinations["Каре"]);
            Console.WriteLine();
            Console.WriteLine("Число комбинаций 'СТРИТ-ФЛЕШ' равно " + _combinations["Стрит-Флеш"] + ", вероятность выпадения: " + (double) _combinations["Стрит-Флеш"]/count*100 + 
                              ", шанс встретить в 1 из " + (double) count/_combinations["Стрит-Флеш"]);
            Console.WriteLine();
            Console.WriteLine("Число комбинаций 'РОЯЛ-ФЛЕШ' равно " + _combinations["Роял-Флеш"] + ", вероятность выпадения: " + (double) _combinations["Роял-Флеш"]/count*100 + 
                              ", шанс встретить в 1 из " + (double) count/_combinations["Роял-Флеш"]);
            Console.WriteLine();
            Console.WriteLine("Число всех сочетаний равно " + count);
            Console.ReadLine();
        }

    }
}