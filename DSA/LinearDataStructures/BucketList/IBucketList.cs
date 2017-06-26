using System.Collections.Generic;

namespace BucketList
{
	public interface IBucketList<T> : IEnumerable<T>
	{
		T this[int index] { get; set; }

		int Size { get; }

		void Add(T value);

		void Insert(int index, T value);

		void Remove(int index);

		void Clear();
	}
}
