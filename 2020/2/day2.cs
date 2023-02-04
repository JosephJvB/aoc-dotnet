using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using Newtonsoft.Json;

namespace _2020
{
    public class Day2
    {
        public static void Solve()
        {
            Solve2();
        }
        private static void Solve2()
        {
            var passwords = Parse();
            var validCount = 0;
            foreach (var pw in passwords)
            {
                var charCount = 0;
                if (pw.Txt[pw.Min - 1] == pw.Char) charCount++;
                if (pw.Txt[pw.Max - 1] == pw.Char) charCount++;
                if (charCount == 1)
                {
                    validCount++;
                }
            }
            Console.WriteLine($"{validCount} / {passwords.Count} passwords are valid");
        }
        private static void Solve1()
        {
            var passwords = Parse();
            var validCount = 0;
            foreach (var pw in passwords)
            {
                var charCount = 0;
                foreach(var c in pw.Txt.ToCharArray())
                {
                    if (c == pw.Char)
                    {
                        charCount++;
                    }
                }
                if (charCount >= pw.Min && charCount <= pw.Max)
                {
                    validCount++;
                }
            }
            Console.WriteLine($"{validCount} / {passwords.Count} passwords are valid");
        }
        private static List<Password> Parse()
        {
            var list = new List<Password>();
            foreach (var line in File.ReadAllLines("2/input.txt"))
            {
                // 2-9 c: ccccccccc
                var pw = new Password();
                var split = line.Split(" ");

                var minMax = split[0].Split("-");
                pw.Min = int.Parse(minMax[0]);
                pw.Max = int.Parse(minMax[1]);
                pw.Char = split[1][0];
                pw.Txt = split[2];

                list.Add(pw);
            }
            return list;
        }
    }
    public class Password
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public char Char { get; set; }
        public string Txt { get; set; }
    }
}