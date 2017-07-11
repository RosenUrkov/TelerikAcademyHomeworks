using System;
using System.IO;
using System.Linq;

namespace ReadAndBuildTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "7\n2 4\n3 2\n5 0\n3 5\n5 6\n5 1";
            Console.SetIn((new StringReader(input)));

            var nodes = int.Parse(Console.ReadLine());
            var collection = Enumerable.Range(0, nodes - 1)
                .Select(x =>
                {
                    return Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToArray();
                })
                .GroupBy(x => x[0])
                .Select(x =>
                {
                    return new TreeNode<int>(x.Key)
                    {
                        Children = x.Select(y => new TreeNode<int>(y[1]))
                    };
                })
                .ToList();

            var root = collection.Select(x =>
             {
                 x.Children = x.Children.Select(y =>
                 {
                     return collection.FirstOrDefault(z => y.Value == z.Value) ?? y;
                 });

                 return x;
             })
            .First(x => x.Children.All(y => collection.Any(z => y.Value == z.Value)));

            foreach (var item in new TreeSet<int>(root))
            {
                Console.WriteLine(item);
            }
        }
    }
}
