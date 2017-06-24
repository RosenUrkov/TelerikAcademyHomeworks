using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BucketList
{
    public class BucketList<T> : IBucketList<T>
    {
        private List<Bucket<T>> buckets;
        private int listBucketsCapacity;
        private int bucketCapacity;

        public BucketList()
        {
            this.listBucketsCapacity = 4;
            this.bucketCapacity = 4;

            this.buckets = new List<Bucket<T>>();
            this.buckets.AddRange(Enumerable.Repeat(new Bucket<T>(bucketCapacity), listBucketsCapacity));
        }

        public int Size => this.buckets.Select(x => x.Size).Sum();

        public int Capacity => this.listBucketsCapacity * this.bucketCapacity;

        public void Clear() => this.buckets.ForEach(x => x.Clear());

        public T this[int index]
        {
            get => this.buckets[index / this.bucketCapacity][index % this.bucketCapacity];
            set => this.buckets[index / this.bucketCapacity][index % this.bucketCapacity] = value;
        }

        public void Add(T value)
        {
            if (this.Size >= this.Capacity)
            {
                this.Resize();
            }

            this.buckets.First(x => x.Capacity > x.Size).Add(value);
        }

        public void Insert(int index, T value)
        {
            if (this.Size >= this.Capacity)
            {
                this.Resize();
            }

            int indexInBucket = index % this.bucketCapacity;
            int listBucketIndex = index / this.bucketCapacity;
            var bucket = this.buckets[listBucketIndex];

            T swapDummy = default(T);
            for (int i = indexInBucket; i < this.bucketCapacity - indexInBucket; i++)
            {
                if (i == indexInBucket)
                {
                    swapDummy = bucket[i];
                    bucket[i] = value;
                    continue;
                }

                var temp = bucket[i];
                bucket[i] = swapDummy;
                swapDummy = temp;
            }

            listBucketIndex++;
            while (++listBucketIndex < this.listBucketsCapacity)
            {
                bucket = this.buckets[listBucketIndex];

                var temp = bucket[bucket.EndIndex];
                bucket[bucket.EndIndex] = swapDummy;
                swapDummy = temp;

                bucket.StartIndex = bucket.EndIndex;

                listBucketIndex++;
            }

            this.buckets.Last().Add(swapDummy);
        }

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var bucket in this.buckets)
            {
                foreach (var element in bucket)
                {
                    yield return element;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            if (this.listBucketsCapacity < 2 * this.bucketCapacity)
            {
                this.buckets.Add(new Bucket<T>(this.bucketCapacity));

                this.listBucketsCapacity++;
                return;
            }

            var newSquareCapacity = this.bucketCapacity + this.bucketCapacity / 2;
            this.listBucketsCapacity = newSquareCapacity;
            this.bucketCapacity = newSquareCapacity;

            var newBuckets = new List<Bucket<T>>();
            newBuckets.AddRange(Enumerable.Repeat(new Bucket<T>(this.bucketCapacity), this.listBucketsCapacity));

            int bucketIndex = 0;
            this.buckets.ForEach(oldBucket =>
            {
                foreach (var element in oldBucket)
                {
                    if (newBuckets[bucketIndex].IsFull)
                    {
                        bucketIndex++;
                    }

                    newBuckets[bucketIndex].Add(element);
                }
            });

            this.buckets = newBuckets;
        }
    }
}
