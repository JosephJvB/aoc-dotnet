using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace _2020
{
    public class Day6
    {
        public static void Solve()
        {
            Solve2();
        }
        private static void Solve2()
        {
            var groups = Parse();
            var totalScore = 0;
            foreach (var g in groups)
            {
                var groupAnswers = new Dictionary<char, int>();
                foreach (var person in g)
                {
                    foreach (var letter in person.ToCharArray())
                    {
                        if (!groupAnswers.ContainsKey(letter))
                        {
                            groupAnswers.Add(letter, 0);
                        }
                        groupAnswers[letter]++;
                    }
                }
                foreach (var letter in groupAnswers.Keys)
                {
                    if (groupAnswers[letter] == g.Count)
                    {
                        totalScore++;
                    }
                }
            }
            Console.WriteLine($"TotalScore: {totalScore}");
        }
        private static void Solve1()
        {
            var groups = Parse();
            // Console.WriteLine(JsonConvert.SerializeObject(groups));
            var totalScore = 0;
            foreach (var g in groups)
            {
                var uniqueYesAnswers = new HashSet<char>();
                foreach (var person in g)
                {
                    foreach (var letter in person.ToCharArray())
                    {
                        uniqueYesAnswers.Add(letter);
                    }
                }
                totalScore += uniqueYesAnswers.Count;
                // Console.WriteLine($"groupScore: {uniqueYesAnswers.Count}");
            }
            Console.WriteLine($"TotalScore: {totalScore}");
        }
        private static List<List<string>> Parse()
        {
            var text = File.ReadAllText("6/input.txt");
            return text.Split("\n\n").ToList()
            .Select(g => g.Split("\n").ToList()).ToList();
        }
    }
}