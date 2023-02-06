using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace _2020
{
    public class Day5
    {
        private static readonly int Rows = 128;
        private static readonly int Cols = 8;
        public static void Solve()
        {
            Solve2();
        }
        private static void Solve2()
        {
            var lines = File.ReadAllLines("5/input.txt");
            var seatIds = new List<int>();
            foreach (var line in lines)
            {
                var seatPos = GetSeatPos(line);
                var id = seatPos[0] * 8 + seatPos[1];
                // Console.WriteLine($"{line}, r:{seatPos[0]} c:{seatPos[1]} id:{id}");
                seatIds.Add(id);
            }
            seatIds.Sort();
            // Console.WriteLine($"seatRange: {seatIds.First()}-{seatIds.Last()}");
            var last = seatIds[0];
            for (var i = 1; i < seatIds.Count - 1; i++)
            {
                var s = seatIds[i];
                if (seatIds[i] - last != 1)
                {
                    Console.WriteLine($"my seat {last + 1}");
                }
                last = s;
            }
        }
        private static void Solve1()
        {
            var lines = File.ReadAllLines("5/input.txt");
            var highest = 0;
            foreach (var line in lines)
            {
                var seatPos = GetSeatPos(line);
                var id = seatPos[0] * 8 + seatPos[1];
                // Console.WriteLine($"{line}, r:{seatPos[0]} c:{seatPos[1]} id:{id}");
                highest = Math.Max(id, highest);
            }
            Console.WriteLine($"highest seatID: {highest}");
        }
        private static int[] GetSeatPos(string line)
        {
            var rMin = 0;
            var rMax = Rows;
            for (var i = 0; i < 7; i++)
            {
                var c = line[i];
                var rHalf = (rMax - rMin) / 2;
                if (c == 'F')
                {
                    rMax -= rHalf;
                }
                else
                {
                    rMin += rHalf;
                }
                // Console.WriteLine($"{i}:{c} rowRange {rMin}-{rMax}");
            }
            var cMin = 0;
            var cMax = Cols;
            for (var i = 7; i < line.Length; i++)
            {
                var c = line[i];
                var cHalf = (cMax - cMin) / 2;
                if (c == 'L')
                {
                    cMax -= cHalf;
                }
                else
                {
                    cMin += cHalf;
                }
                // Console.WriteLine($"{i}:{c} colRange {cMin}-{cMax}");
            }
            return new int[]
            {
                rMin,
                cMax - 1,
            };
        }
    }
}