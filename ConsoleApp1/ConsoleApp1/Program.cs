using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        private static int start;
        private static int end;
        private static ulong tSum;
        private static bool gotFlag;
        static void Main(string[] args)
        {
            Console.WriteLine("Дан List<uint> list и некое число ulong sum. Ожидаемое количество элементов в list - несколько миллионов. Необходимо написать метод FindElementsForSum, который сможет найти наименьшие индексы start и end такие, что сумма элементов list начиная с индекса start включительно и до индекса end не включительно будет в точности равна sum. Если таких start и end нельзя найти, то установить start и end равными 0");

            //Console.WriteLine("Введите размер массива:");
            //int len = int.Parse(Console.ReadLine());
            //uint[] arr = new uint[len];
            //Console.WriteLine("Введите порядок случайных чисел через (Пробел), в соответствие указанному размеру массива:");
            //string[] arrayNumber = Console.ReadLine().Split(' ');
            //for (int i = 0; i < arrayNumber.Length; i++)
            //{
            //    arr[i] = uint.Parse(arrayNumber[i]);
            //}
            //List<uint> list = arr.ToList();
 
            List<uint> list = new List<uint>();

            Console.WriteLine("Введите размер списка:");
            int len = int.Parse(Console.ReadLine());
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine("Введите значение: ");
                list.Add(uint.Parse(Console.ReadLine())); 
            }

            Console.WriteLine("Введите sum:");
            ulong sum = ulong.Parse(Console.ReadLine());

            FindElementsForSum(list, sum, out start, out end);
            Console.WriteLine("Получается start=" + start + ", а end= " + end);
        }
        public static void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
        {
            start = 0;
            end = 0;
            for (int i = 0; i <= list.Count; i++)
            {
                tSum = 0;
                for (int j = i; j <= list.Count; j++)
                {
                    tSum += list[j];
                    if (tSum == sum)
                    {
                        Console.WriteLine($"попался! tSum = {tSum}, start = {i}, end = {j+1}");
                        start = i;
                        end = j+1;
                        gotFlag = true;
                    }
                    if (gotFlag || tSum > sum) break;
                }
                if (gotFlag) break;
            }
        }
    }
}
