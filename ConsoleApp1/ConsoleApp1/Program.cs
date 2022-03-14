using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            
            Console.WriteLine("Введите размер списка:");
            int numOfInts = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите максимально допустимое значение элемента списка:");
            int maxValue = int.Parse(Console.ReadLine());
            
            Random rand = new Random();
            var list = Enumerable.Range(0, numOfInts)
                .Select(i => (uint)rand.Next(maxValue)+1)
                .ToList();
            var array = list.ToArray();

            Console.WriteLine("Введите sum:");
            ulong sum = ulong.Parse(Console.ReadLine());
            var sw = new Stopwatch();
            sw.Start();
            FindElementsForSum(list, sum, out start, out end);
            sw.Stop();
            Console.WriteLine($"List. Получается start = {start}, а end = {end}. Затрачено времени {sw.Elapsed.Milliseconds} мс.");
            sw.Restart();
            FindElementsForSum(array, sum, out start, out end);
            sw.Stop();
            Console.WriteLine($"Array. Получается start = {start}, а end = {end}. Затрачено времени {sw.Elapsed.Milliseconds} мс.");
            

        }
        public static void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
        {
            start = 0;
            end = 0;
            for (int i = 0; i < list.Count; i++)
            {
                tSum = 0;
                for (int j = i; j < list.Count; j++)
                {
                    tSum += list[j];
                    if (tSum == sum)
                    {
                        Console.WriteLine($"Попался! tSum = {tSum}, start = {i}, end = {j+1}");
                        start = i;
                        end = j+1;
                        gotFlag = true;
                    }
                    if (gotFlag || tSum > sum) break;
                }
                if (gotFlag) break;
            }
        }
        public static void FindElementsForSum(uint[] list, ulong sum, out int start, out int end)
        {
            start = 0;
            end = 0;
            for (int i = 0; i < list.Length; i++)
            {
                tSum = 0;
                for (int j = i; j < list.Length; j++)
                {
                    tSum += list[j];
                    if (tSum == sum)
                    {
                        Console.WriteLine($"Попался! tSum = {tSum}, start = {i}, end = {j+1}");
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
