using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace _2020
{
    public class Day3
    {
        public static void Solve()
        {
            Solve2();
        }
        private static void Solve2()
        {
            var grid = Parse();
            var slopes = new List<List<int>>
            {
                new List<int> { 1, 1 },
                new List<int> { 3, 1 },
                new List<int> { 5, 1 },
                new List<int> { 7, 1 },
                new List<int> { 1, 2 },
            };
            long trees = 1;
            foreach (var slope in slopes)
            {
                var t = SolveSlope(grid, slope[0], slope[1]);
                trees *= t;
            }
            Console.WriteLine($"all slopes: {trees}");
        }
        private static int SolveSlope(List<List<char>> grid, int xInc, int yInc)
        {
            var x = 0;
            var y = 0;
            var treeCount = 0;
            while (y <= grid.Count)
            {
                if (grid[y][x] == '#')
                {
                    treeCount++;
                }
                // exit if at bottom
                if (y + yInc >= grid.Count)
                {
                    break;
                }
                // move right 3 down 1
                x += xInc;
                if (x >= grid[y].Count)
                {
                    x = x % grid[y].Count;
                }
                y += yInc;
            }
            return treeCount;
        }
        private static void Solve1()
        {
            var grid = Parse();
            var treeCount = SolveSlope(grid, 3, 1);
            Console.WriteLine($"trees: {treeCount}");
        }
        private static List<List<char>> Parse()
        {
            var grid = new List<List<char>>();
            foreach (var line in File.ReadAllLines("3/input.txt"))
            {
                grid.Add(new List<char>(line.ToCharArray()));
            }
            return grid;
        }
    }
}