using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        private static void Solve2()
        {
            var lines = Parse();
            var validLines = 0;
            var validators = new List<BaseValidator>
            {
                new BYR(),
                new IYR(),
                new EYR(),
                new HGT(),
                new HCL(),
                new ECL(),
                new PID(),
            };
            foreach (var line in lines)
            {
                var split = line.Split(" ").ToList();
                var lineIsValid = validators.All(v => v.Validate(split));
                if (lineIsValid)
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