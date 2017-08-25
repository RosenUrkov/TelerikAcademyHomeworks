using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketQueue
{
    class Program
    {
        static List<string> list = new List<string>();

        static void Main(string[] args)
        {
            var builder = new StringBuilder();
            while (true)
            {
                var command = Console.ReadLine().Split(' ');

                switch (command[0][0])
                {
                    case 'A': builder.AppendLine(AppendCommand(command[1])); break;
                    case 'I': builder.AppendLine(InsertCommand(int.Parse(command[1]), command[2])); break;
                    case 'F': builder.AppendLine(FindCommand(command[1]).ToString()); break;
                    case 'S': builder.AppendLine(ServeCommand(int.Parse(command[1]))); break;
                    case 'E': Console.WriteLine(builder.ToString().TrimEnd()); return;
                }
            }
        }

        static string AppendCommand(string name)
        {
            list.Add(name);
            return "OK";
        }

        static string InsertCommand(int position, string name)
        {
            if (position < 0 || position > list.Count)
            {
                return "Error";
            }

            list.Insert(position, name);
            return "OK";
        }

        static int FindCommand(string name)
        {
            int result = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == name)
                {
                    result++;
                }
            }

            return result;
        }

        static string ServeCommand(int count)
        {
            if (count < 0 || count > list.Count)
            {
                return "Error";
            }

            var result = new StringBuilder();
            var newList = new List<string>();

            for (int i = 0; i < count; i++)
            {
                result.Append(list[i] + " ");
            }
            for (int i = count; i < list.Count; i++)
            {
                newList.Add(list[i]);
            }

            list = newList;
            return result.ToString().TrimEnd();
        }
    }
}
