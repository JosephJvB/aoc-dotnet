using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using Newtonsoft.Json;

namespace _2020
{
    public class Day1
    {
        public static void Solve()
        {
            // Solve1();
            Solve2();
        }
        public static void Solve2()
        {
            var nums = new List<int>();
            foreach (var line in File.ReadAllLines("1/input.txt"))
            {
                nums.Add(int.Parse(line));
            }
            for (var i = 0; i < nums.Count - 2; i++)
            {
                for (var j = i + 1; j < nums.Count - 1; j++)
                {
                    foreach (var num3 in nums.Skip(j + 1))
                    {
                        var num1 = nums[i];
                        var num2 = nums[j];
                        if (num1 + num2 + num3 == 2020)
                        {
                            Console.WriteLine($"found trio: {num1}, {num2}, {num3}. {num1 * num2 * num3}");
                            return;
                        }
                    }
                }
            }
        }
        public static void Solve1()
        {
            var nums = new List<int>();
            foreach (var line in File.ReadAllLines("1/input.txt"))
            {
                nums.Add(int.Parse(line));
            }
            for (var i = 0; i < nums.Count - 1; i++)
            {
                var currentNum = nums[i];
                var rest = nums.Skip(i + 1);
                foreach (var n in rest)
                {
                    if (currentNum + n == 2020)
                    {
                        Console.WriteLine($"found pair {currentNum}, {n}, total: {currentNum * n}");
                        return;
                    }
                }
            }
        }
    }
}
