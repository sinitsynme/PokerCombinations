using System;

namespace ConsoleApp1
{
    public static class Combinations
    {
        public static bool IsPair(int[] values)
        {
            foreach (int count in values)
            {
                if (count == 2)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsTwoPairs(int[] values)
        {
            int pairCount = 0;
            foreach (int count in values)
            {
                if (count == 2)
                {
                    pairCount++;
                }
            }

            return pairCount == 2;

        }

        public static bool IsSet(int[] values)
        {
            foreach (int count in values)
            {
                if (count == 3)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsStraight(int[] values)
        {
            int cardsInRow = 0;
            foreach (int card in values)
            {
                if (card > 1)
                {
                    return false;
                }

                if (card == 1)
                {
                    cardsInRow++;
                }

                if (card == 0)
                {
                    cardsInRow = 0;
                }

                if (cardsInRow == 5)
                {
                    return true;
                }
            }
            
            //краевой случай: A 2 3 4 5
            if (values[12] == 1)
            {
                if (values[0] == 1 && 1 == values[1] && 1 == values[2] && 1 == values[3])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsFlush(int[] suits)
        {
            foreach (int count in suits)
            {
                if (count == 5)
                {
                    return true;
                }
            }

            return false;
        }


        public static bool IsFullHouse(int[] values)
        {
            return IsPair(values) && IsSet(values);
        }

        public static bool IsFourOfAKind(int[] values)
        {
            foreach (int count in values)
            {
                if (count == 4)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsStraightFlush(int[] values, int[] suits)
        {
            return IsStraight(values) && IsFlush(suits);
        }


        public static bool IsRoyalFlush(int[] values, int[] suits)
        {
            for (int i = 8; i < 13; i++)
            {
                if(values[i] != 1)
                {
                    return false;
                }
            }
            return IsStraightFlush(values, suits);
        }
        
        
        
    }
}