using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Frames
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override int GetHashCode()
        {
            return (this.X ^ this.Y).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Point;
            return this.X == other.X && this.Y == other.Y;
        }

        public override string ToString()
        {
            return "(" + this.X + ", " + this.Y + ")";
        }
    }

    public class Program
    {
        static int frameNumber = 0;
        static List<Point> frames = new List<Point>();
        static HashSet<string> resultFrames = new HashSet<string>();
        static bool[] used;

        public static void Main(string[] args)
        {
            frameNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < frameNumber; i++)
            {
                var frame = Console.ReadLine().Split(' ');
                frames.Add(new Point(int.Parse(frame[0]), int.Parse(frame[1])));
                frames.Add(new Point(int.Parse(frame[1]), int.Parse(frame[0])));
            }

            used = new bool[frames.Count];
            resultFrames = new HashSet<string>();

            Recursion(new List<Point>());

            var result = resultFrames.ToList();
            result.Sort();

            Console.WriteLine(resultFrames.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void Recursion(List<Point> currentResult)
        {
            if (currentResult.Count == frameNumber)
            {
                resultFrames.Add(string.Join(" | ", currentResult));
                return;
            }

            for (int i = 0; i < frames.Count; i++)
            {
                if (used[i])
                {
                    continue;
                }

                var mirror = i % 2 == 0 ? i + 1 : i - 1;
                used[i] = true;
                used[mirror] = true;

                Recursion(new List<Point>(currentResult) { frames[i] });

                used[i] = false;
                used[mirror] = false;
            }
        }
    }
}
