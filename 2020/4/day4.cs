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
    public class Day4
    {
        private static List<string> Fields = new List<string>
        {
            "byr", // (Birth Year)
            "iyr", // (Issue Year)
            "eyr", // (Expiration Year)
            "hgt", // (Height)
            "hcl", // (Hair Color)
            "ecl", // (Eye Color)
            "pid", // (Passport ID)
            // "cid", // (Country ID)
        };
        public static void Solve()
        {
            Solve2();
        }
        private static bool IntBetween(string s, int min, int max)
        {
            var parsed = int.TryParse(s, out int n);
            if (!parsed)
            {
                return false;
            }
            return n >= min && n <= max;
        }
        // very ugly method
        private static bool ValidateField(string pair)
        {
            var split = pair.Split(":");
            var validHairColourChars = "0123456789abcdef";
            var validEyeColours = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            // Console.WriteLine($"{pair} - {split[0]} {split[1]}");
            switch (split[0])
            {
                case "byr": // (Birth Year)
                    return IntBetween(split[1], 1920, 2004);
                case "iyr": // (Issue Year)
                    return IntBetween(split[1], 2010, 2020);
                case "eyr": // (Expiration Year)
                    return IntBetween(split[1], 2020, 2030);
                case "hgt": // (Height)
                    if (split[1].Contains("cm"))
                    {
                        return IntBetween(split[1].Replace("cm", ""), 150, 193);
                    }
                    else if (split[1].Contains("in"))
                    {
                        return IntBetween(split[1].Replace("in", ""), 59, 76);
                    }
                    return false;
                case "hcl": // (Hair Color)
                    return split[1].StartsWith("#")
                    && split[1].Length == 7
                    && split[1].ToCharArray().ToList().Skip(1).All(c => validHairColourChars.Contains(c));
                case "ecl": // (Eye Color)
                    return validEyeColours.Contains(split[1]);
                case "pid": // (Passport ID)
                    return split[1].Length == 9 && int.TryParse(split[1], out int n);
            }
            return true;
        }
        private static void Solve2()
        {
            var lines = Parse();
            var validLines = 0;
            foreach (var line in lines)
            {
                var split = line.Split(" ");
                var validFields = new HashSet<string>();
                foreach (var f in Fields)
                {
                    var pair = split.Where(c => c.StartsWith(f)).FirstOrDefault();
                    if (pair != null && ValidateField(pair))
                    {
                        validFields.Add(f);
                    }
                }
                // Console.WriteLine($"{line}, {JsonConvert.SerializeObject(validFields)}");
                if (validFields.Count == Fields.Count)
                {
                    validLines++;
                }
            }
            Console.WriteLine($"{validLines} / {lines.Count} lines are valid");
        }
        private static void Solve1()
        {
            var lines = Parse();
            var validLines = 0;
            foreach (var line in lines)
            {
                var foundFields = new HashSet<string>();
                foreach (var f in Fields)
                {
                    if (line.Contains(f + ":"))
                    {
                        foundFields.Add(f);
                    }
                }
                if (foundFields.Count == Fields.Count)
                {
                    validLines++;
                }
            }
            Console.WriteLine($"{validLines} / {lines.Count} lines are valid");
        }
        private static List<string> Parse()
        {
            return File.ReadAllText("4/input.txt").Split("\n\n").ToList()
            .Select(s => s.Replace("\n", " ")).ToList();
        }
    }
}