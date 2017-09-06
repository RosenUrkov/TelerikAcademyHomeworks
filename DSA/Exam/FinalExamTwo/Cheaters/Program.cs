using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace GraphsAlgorithms
{
    class TopoNode
    {
        public string Name { get; set; }
        public LinkedList<string> Parents { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as TopoNode;
            return this.Name == other.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }

    public class Program
    {
        static void ReadDirectedGraph()
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var edge = Console.ReadLine().Split(' ');

                var y = edge[0];
                var x = edge[1];

                var subject = "";
                var builder = new StringBuilder();
                for (int j = 2; j < edge.Length; j++)
                {
                    builder.Append(edge[j] + " ");
                }
                builder.Length--;
                subject = builder.ToString();

                if (!subjects.ContainsKey(subject))
                {
                    subjects[subject] = new Dictionary<string, TopoNode>();
                }

                if (!subjects[subject].ContainsKey(x))
                {
                    subjects[subject][x] = new TopoNode
                    {
                        Name = x,
                        Parents = new LinkedList<string>()
                    };
                }

                if (!subjects[subject].ContainsKey(y))
                {
                    subjects[subject][y] = new TopoNode
                    {
                        Name = y,
                        Parents = new LinkedList<string>()
                    };
                }

                subjects[subject][y].Parents.AddFirst(x);
            }
        }

        static Dictionary<string, Dictionary<string, TopoNode>> subjects = new Dictionary<string, Dictionary<string, TopoNode>>();

        static HashSet<int> parentHashes = new HashSet<int>();
        static Deque<string> parents = new Deque<string>();
        static string subject = "";

        static void Main()
        {
            ReadDirectedGraph();

            var n = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine();
                var index = command.IndexOf(" ");

                var name = command.Substring(0, index);
                subject = command.Substring(index + 1);

                var current = subjects[subject][name];

                parentHashes = new HashSet<int>();
                parents = new Deque<string>();

                GetParents(current);

                builder.AppendLine(string.Join(", ", parents));
            }

            Console.WriteLine(builder.ToString().TrimEnd());
        }

        static void GetParents(TopoNode node)
        {
            parents.PushFront(node.Name);
            parentHashes.Add(node.GetHashCode());

            foreach (var item in node.Parents)
            {
                if (!parentHashes.Contains(item.GetHashCode()))
                {
                    GetParents(subjects[subject][item]);
                }
            }
        }
    }

    public class Deque<T> : IEnumerable<T>
    {
        private const int MIN_CAPACITY = 4;

        private T[] buffer;
        private int startIndex;
        private int size;
        private int endIndex;

        public Deque()
        {
            buffer = null;
            startIndex = 0;
            size = 0;
            endIndex = 0;
        }

        public int Size
        {
            get
            {
                return this.size;
            }
        }

        public bool Empty
        {
            get
            {
                return this.size == 0;
            }
        }

        public int Capacity
        {
            get
            {
                return this.buffer.Length;
            }
        }

        public T Front
        {
            get
            {
                return this.buffer[startIndex];
            }
        }

        public T Back
        {
            get
            {
                return this.buffer[PrevIndex(endIndex)];
            }
        }

        public void PushBack(T value)
        {
            MakeSpaceForOneMoreIfNeeded();

            buffer[endIndex] = value;
            endIndex = NextIndex(endIndex);
            ++size;
        }

        public void PushFront(T value)
        {
            MakeSpaceForOneMoreIfNeeded();

            startIndex = PrevIndex(startIndex);
            buffer[startIndex] = value;
            ++size;
        }

        public void PopBack()
        {
            endIndex = PrevIndex(endIndex);
            buffer[endIndex] = default(T);
            --size;
        }

        public void PopFront()
        {
            buffer[startIndex] = default(T);
            startIndex = NextIndex(startIndex);
            --size;
        }

        public void Reserve(int newSize)
        {
            if (newSize < size)
            {
                return;
            }

            var newBuffer = new T[newSize];

            for (int i = 0, j = startIndex;
                i < size;
                ++i, j = NextIndex(j))
            {
                newBuffer[i] = buffer[j];
            }

            startIndex = 0;
            endIndex = size;
            buffer = newBuffer;
        }

        private int NextIndex(int index)
        {
            ++index;
            if (index == buffer.Length)
            {
                index = 0;
            }
            return index;
        }

        private int PrevIndex(int index)
        {
            if (index == 0)
            {
                index = buffer.Length;
            }
            --index;
            return index;
        }

        private void MakeSpaceForOneMoreIfNeeded()
        {
            if (buffer == null)
            {
                buffer = new T[MIN_CAPACITY];
            }
            else if (size == buffer.Length)
            {
                Reserve(size * 2);
            }
        }

        public T this[int index]
        {
            get
            {
                return buffer[AdaptIndex(index)];
            }
            set
            {
                buffer[AdaptIndex(index)] = value;
            }
        }

        private int AdaptIndex(int index)
        {
            int realIndex = startIndex + index;
            if (realIndex >= buffer.Length)
            {
                realIndex -= buffer.Length;
            }

            return realIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = startIndex, j = 0;
                j < size;
                i = NextIndex(i), ++j)
            {
                yield return buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
