using System;
using System.Collections;
using System.Collections.Generic;

namespace HashSet
{
    public class HashSet<T> : IEnumerable<T>
    {
        // most optimised coeffs -> no idea
        private const int InitialBufferSize = 16;
        private const int CapacityGrowthCoefficient = 8;
        private const double ResizingCoefficient = 0.3;

        private int count;
        private int bufferCapacity;
        private List<uint> usedIndexes;
        private LinkedNode<T>[] buffer;

        public HashSet()
        {
            this.count = 0;
            this.bufferCapacity = InitialBufferSize;
            this.usedIndexes = new List<uint>();
            this.buffer = new LinkedNode<T>[InitialBufferSize];
        }

        public int Count => this.count;

        public bool Add(T value)
        {
            if ((double)this.count / this.bufferCapacity >= ResizingCoefficient)
            {
                this.bufferCapacity *= CapacityGrowthCoefficient;
                Resize(this.bufferCapacity);
            }

            uint index = this.GetIndexFromValue(value);
            if (this.buffer[index] is null)
            {
                this.buffer[index] = new LinkedNode<T>(value, null);
                this.usedIndexes.Add(index);
                this.count++;
                return true;
            }

            if (this.buffer[index].Contains(value))
            {
                return false;
            }

            this.buffer[index] = new LinkedNode<T>(value, this.buffer[index]);
            this.count++;
            return true;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < this.usedIndexes.Count; i++)
            {
                if (this.buffer[this.usedIndexes[i]].Contains(value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T value)
        {
            uint index = this.GetIndexFromValue(value);
            if (this.usedIndexes.Contains(index))
            {
                var node = this.buffer[index];
                if (node.Value.Equals(value))
                {
                    this.buffer[index] = node.Next;
                    if (node.Next is null)
                    {
                        this.usedIndexes.Remove(index);
                    }

                    this.count--;
                    return true;
                }

                while (true)
                {
                    var nextNode = node.Next;
                    if (nextNode is null)
                    {
                        return false;
                    }

                    if (nextNode.Value.Equals(value))
                    {
                        node.Next = nextNode.Next;
                        this.count--;
                        return true;
                    }

                    node = nextNode;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.count = 0;
            this.bufferCapacity = InitialBufferSize;
            this.usedIndexes = new List<uint>();
            this.buffer = new LinkedNode<T>[InitialBufferSize];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.usedIndexes.Count; i++)
            {
                var node = this.buffer[this.usedIndexes[i]];                
                while(node!= null)
                {
                    yield return node.Value;
                    node = node.Next;
                }                
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private uint GetIndexFromValue(T value)
        {
            return (uint)value.GetHashCode() % (uint)this.bufferCapacity;
        }

        private void Resize(int newBufferSize)
        {
            var newBuffer = new LinkedNode<T>[newBufferSize];
            var newUsedIndexes = new List<uint>();

            for (int i = 0; i < this.usedIndexes.Count; i++)
            {
                var node = this.buffer[this.usedIndexes[i]];
                while (node != null)
                {
                    uint index = this.GetIndexFromValue(node.Value);
                    if (newBuffer[index] is null)
                    {
                        newBuffer[index] = new LinkedNode<T>(node.Value, null);
                        newUsedIndexes.Add(index);
                    }
                    else
                    {
                        newBuffer[index] = new LinkedNode<T>(node.Value, newBuffer[index]);
                    }

                    node = node.Next;
                }
            }

            this.buffer = newBuffer;
            this.usedIndexes = newUsedIndexes;


        }
    }
}