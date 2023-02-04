using System.Collections.Generic;
using System.Linq;

namespace _2020
{
    public abstract class BaseValidator
    {
        public abstract bool Validate(List<string> pairs);
        public bool IntBetween(string s, int min, int max)
        {
            var parsed = int.TryParse(s, out int n);
            if (!parsed)
            {
                return false;
            }
            return n >= min && n <= max;
        }
    }
    public class BYR : BaseValidator
    {
        override public bool Validate(List<string> pairs)
        {
            var pair = pairs.Find(p => p.StartsWith("byr"));
            if (pair == null)
            {
                return false;
            }
            var split = pair.Split(":");
            return IntBetween(split[1], 1920, 2004);
        }
    }
    public class IYR : BaseValidator
    {
        override public bool Validate(List<string> pairs)
        {
            var pair = pairs.Find(p => p.StartsWith("iyr"));
            if (pair == null)
            {
                return false;
            }
            var split = pair.Split(":");
            return IntBetween(split[1], 2010, 2020);
        }
    }
    public class EYR : BaseValidator
    {
        override public bool Validate(List<string> pairs)
        {
            var pair = pairs.Find(p => p.StartsWith("eyr"));
            if (pair == null)
            {
                return false;
            }
            var split = pair.Split(":");
            return IntBetween(split[1], 2020, 2030);
        }
    }
    public class HGT : BaseValidator
    {
        override public bool Validate(List<string> pairs)
        {
            var pair = pairs.Find(p => p.StartsWith("hgt"));
            if (pair == null)
            {
                return false;
            }
            var split = pair.Split(":");
            if (split[1].Contains("cm"))
            {
                return IntBetween(split[1].Replace("cm", ""), 150, 193);
            }
            else if (split[1].Contains("in"))
            {
                return IntBetween(split[1].Replace("in", ""), 59, 76);
            }
            return false;
        }
    }
    public class HCL : BaseValidator
    {
        public readonly string ValidHairColourChars = "0123456789abcdef";
        override public bool Validate(List<string> pairs)
        {
            var pair = pairs.Find(p => p.StartsWith("hcl"));
            if (pair == null)
            {
                return false;
            }
            var split = pair.Split(":");
            return split[1].StartsWith("#")
            && split[1].Length == 7
            && split[1].ToCharArray().ToList().Skip(1).All(c => ValidHairColourChars.Contains(c));
        }
    }
    public class ECL : BaseValidator
    {
        public readonly List<string> ValidEyeColours = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        override public bool Validate(List<string> pairs)
        {
            var pair = pairs.Find(p => p.StartsWith("ecl"));
            if (pair == null)
            {
                return false;
            }
            var split = pair.Split(":");
            return ValidEyeColours.Contains(split[1]);
        }
    }
    public class PID : BaseValidator
    {
        override public bool Validate(List<string> pairs)
        {
            var pair = pairs.Find(p => p.StartsWith("pid"));
            if (pair == null)
            {
                return false;
            }
            var split = pair.Split(":");
            return split[1].Length == 9 && int.TryParse(split[1], out int n);
        }
    }
}