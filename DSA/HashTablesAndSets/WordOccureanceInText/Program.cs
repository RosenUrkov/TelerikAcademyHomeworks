using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordOccureanceInText
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var regex = new Regex(@"\w+");
            var text = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";

            var dictionary = new Dictionary<string, int>();

            regex.Matches(text)
                .Cast<Match>()
                .Select(x => x.Value.ToLower())
                .ToList()
                .ForEach(x =>
                {
                    if (dictionary.ContainsKey(x))
                    {
                        dictionary[x]++;
                        return;
                    }

                    dictionary.Add(x, 1);
                });

            dictionary
                .OrderBy(x => x.Value)
                .ToList()
                .ForEach(x=> Console.WriteLine(x.Key + " -> " + x.Value));
        }
    }
}
