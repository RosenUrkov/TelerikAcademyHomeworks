using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MessagesInABottle
{
    public class Program
    {
        public static Dictionary<string, char> cypher;
        public static SortedSet<string> result;

        public static void Main(string[] args)
        {
            var message = Console.ReadLine();
            cypher = new Dictionary<string, char>();

            var matches = Regex.Matches(Console.ReadLine(), "[A-Z][0-9]+");
            foreach (var item in matches)
            {
                var match = item as Match;
                cypher.Add(match.Value.Substring(1), match.Value[0]);
            }

            result = new SortedSet<string>();
            Recursion(0, message);

            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void Recursion(int index, string msg)
        {
            var decyphered = true;
            for (int i = 0; i < msg.Length; i++)
            {
                if (char.IsDigit(msg[i]))
                {
                    decyphered = false;
                    break;
                }
            }

            if (decyphered)
            {
                result.Add(msg);
                return;
            }

            var newMsg = string.Empty;
            string key = string.Empty;
            for (int i = index; i < msg.Length; i++)
            {
                key += msg[i];
                if (TryDecypher(msg, key, index, out newMsg))
                {
                    Recursion(index + 1, newMsg);
                }
            }
        }

        public static bool TryDecypher(string msg, string charCypher, int index, out string result)
        {
            if (cypher.ContainsKey(charCypher))
            {
                result = msg.Substring(0, index) + cypher[charCypher] + msg.Substring(index + charCypher.Length);
                return true;
            }

            result = msg;
            return false;
        }
    }
}
