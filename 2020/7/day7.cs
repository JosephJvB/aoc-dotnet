using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;

namespace _2020
{
    public class Day7
    {
        public static void Solve()
        {
            Solve2();
        }
        private static void Solve2()
        {
            var rules = Parse();
            var myBag = "shiny-gold";
            var totalBags = 0;
            var innerBags = rules[myBag].Contents.Select(c => new InnerBag
            {
                Colour = c.Key,
                Quantity = c.Value,
            }).ToList();
            while (innerBags.Count > 0)
            {
                var n = innerBags[0];
                innerBags.RemoveAt(0);

                totalBags += n.Quantity;
                foreach (var inner in rules[n.Colour].Contents)
                {
                    innerBags.Add(new InnerBag
                    {
                        Colour = inner.Key,
                        Quantity = n.Quantity * inner.Value
                    });
                }
            }
            Console.WriteLine($"bags that contain {myBag}: {totalBags}");
        }
        private static void Solve1()
        {
            var rules = Parse();
            var myBag = "shiny-gold";
            var containsMyBag = new HashSet<string>();
            var outerColours = rules.Keys.Where(colour => rules[colour].Contents.ContainsKey(myBag)).ToList();
            while (outerColours.Count > 0)
            {
                var n = outerColours[0];
                outerColours.RemoveAt(0);

                if(containsMyBag.Contains(n))
                {
                    continue;
                }

                containsMyBag.Add(n);
                foreach (var colour in rules.Keys)
                {
                    if (rules[colour].Contents.ContainsKey(n))
                    {
                        outerColours.Add(colour);
                    }
                }
            }
            Console.WriteLine($"bags that contain {myBag}: {containsMyBag.Count}");
        }
        private static Dictionary<string, BagRule> Parse()
        {
            var lines = File.ReadAllLines("7/input.txt");
            // muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
            var rules = new Dictionary<string, BagRule>();
            foreach (var l in lines)
            {
                var s = l.Split(" ");
                var colour = $"{s[0]}-{s[1]}";
                rules[colour] = new BagRule();
                var contains = l.Split("contain ");
                if (contains[1].StartsWith("no"))
                {
                    continue;
                }
                foreach (var inner in contains[1].Split(", "))
                {
                    var innerSplit = inner.Split(" ");
                    var quantity = int.Parse(innerSplit[0]);
                    var innerColour = $"{innerSplit[1]}-{innerSplit[2]}";
                    rules[colour].Contents.Add(innerColour, quantity);
                }
            }
            return rules;
        }
    }
    public class InnerBag
    {
        public string Colour { get; set; }
        public int Quantity { get; set; }
    }
    public class BagRule
    {
        public BagRule()
        {
            Contents = new Dictionary<string, int>();
        }
        public Dictionary<string, int> Contents { get; set; }
    }
}