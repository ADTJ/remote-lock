using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    static string LinqMostCommonCharacterIn(string input)
    {
        var grouped = input.ToCharArray()
            .GroupBy(x => x)
            .Where(g => !char.IsWhiteSpace(g.Key) && char.IsLetter(g.Key))
            .Select(g => new { g.Key, Value = g.Count() })
            .OrderBy(g => g.Key);

        return grouped.Where(g => g.Value == grouped.Max(x => x.Value)).FirstOrDefault().Key.ToString();
    }

    static string NoLinqMostCommonCharacterIn(string input)
    {
        if (input.Length < 1) return string.Empty;
        var dict = new Dictionary<char, int>();

        foreach (char ch in input)
        {
            if (!char.IsLetter(ch))
                continue;

            if (dict.ContainsKey(ch))
                ++dict[ch];
            else
                dict.Add(ch, 1);
        }

        int biggestCount = 0;
        char biggestChar = ' ';

        foreach(char ch in dict.Keys)
        {
            if(dict[ch] > biggestCount || (dict[ch] == biggestCount && ch < biggestChar))
            {
                biggestCount= dict[ch];
                biggestChar = ch;
            }
        }

        return biggestChar.ToString();
    }

    static bool IsPalindrome(string input)
    {
        input = string.Concat(input.ToLower().Where(ch => char.IsLetter(ch)));

        for (int i = 0; i < (input.Length + 1) / 2; ++i)
            if (input[i] != input[(input.Length - 1) - i])
                return false;

        return true;
    }

    static List<string> ParseNames(List<string> names)
    {
        var output = new List<string>();

        foreach(var str in names)
        {
            foreach (var substr in str.Split(' '))
                output.Add($"{substr} is from {str}");
        }

        return output;
    }

    // Complete the FizzBuzz function below.
    static void FizzBuzz(int upperBound)
    {
        PrintCases(new OutputCase[]
        {
            new OutputCase { divisor = 3, output = "Fizz" },
            new OutputCase { divisor = 5, output = "Buzz" }
        }, upperBound);
    }

    struct OutputCase
    {
        public int divisor;
        public string output;
    }

    static void PrintCases(IEnumerable<OutputCase> cases, int upperBound)
    {
        for(int i = 1; i <= upperBound; ++i)
        {
            string output = string.Empty;

            foreach (var ocase in cases)
                if (i % ocase.divisor == 0)
                    output += ocase.output;

            if (output == string.Empty)
                output = i.ToString();

            Console.WriteLine(output);
        }
    }
}
