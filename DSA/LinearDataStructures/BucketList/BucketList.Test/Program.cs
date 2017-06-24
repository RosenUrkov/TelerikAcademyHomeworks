using System;
using System.Diagnostics;

namespace BucketList.Demo
{
	class Program
	{
		public static void Main(string[] args)
		{
			for (int i = 0; i < 32; ++i)
			{
				var list = new BucketList<int>();
				var time = TestBucketList(list, 10000, 10000, 10000, 10000);
				Console.WriteLine(time);
			}
		}

		// not perfect, but it's something
		public static TimeSpan TestBucketList(
			IBucketList<int> list,
			int addOperations,
			int insertOperations,
			int modifyIndexOperations,
			int removeOperations)
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();

			var rnd = new Random();
			while (addOperations > 0 || insertOperations > 0)
			{
				var op = rnd.Next() % 4;
				if ((op == 0 || (addOperations <= 0 && insertOperations <= 0))
				    && removeOperations > 0 && list.Size > 0)
				{
					var index = rnd.Next() % list.Size;
					//list.Remove(index);
					--removeOperations;
				}
				else if (op == 1 && modifyIndexOperations > 0 && list.Size > 0)
				{
					var index = rnd.Next() % list.Size;
					var value = rnd.Next();
					list[index] = list[index] + value;
					--modifyIndexOperations;
				}
				else if (op == 2 && insertOperations > 0)
				{
					var index = rnd.Next() % (list.Size + 1);
					var value = rnd.Next();
					list.Insert(index, value);
					--insertOperations;
				}
				else
				{
					var value = rnd.Next();
					list.Add(value);
					--addOperations;
				}
			}

			stopWatch.Stop();
			return stopWatch.Elapsed;
		}
	}
}
