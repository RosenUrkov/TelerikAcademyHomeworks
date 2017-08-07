using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MutithreadingAndAsyncProgramming
{
    public class Cycles : ICycles
    {
        public void StartCycling(int number)
        {
            this.MultithreadAsyncCycle(number);
            this.ThreadAsyncCycle(number);

            this.ParallelAsyncCycle(number);
            this.ParallelSyncConcurentStructureCycle(number);
            this.ParallelSyncCycle(number);
            
            this.AsyncCycle(number);
            this.SyncCycle(number);

            Console.ReadLine();
        }

        public void SyncCycle(int num)
        {
            Console.WriteLine("Sync started!");

            var number = 0;
            for (int i = 0; i < num; i++)
            {
                number++;
            }

            Console.WriteLine("Sync ended! " + number);
        }

        public async void AsyncCycle(int num)
        {
            Console.WriteLine("Async started!");

            var number = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < num; i++)
                {
                    number++;
                }
            });

            Console.WriteLine("Async ended! " + number);
        }

        public void ParallelSyncCycle(int num)
        {
            Console.WriteLine("Parallel sync started!");

            var number = 0;
            Parallel.For(0, num, (index, loopState) =>
            {
                Interlocked.Increment(ref number);
            });

            Console.WriteLine("Parallel sync ended! " + number);
        }

        public void ParallelSyncConcurentStructureCycle(int num)
        {
            Console.WriteLine("Parallel sync concurent structure started!");

            var bag = new ConcurrentBag<int>();
            Parallel.For(0, num, (index, loopState) =>
            {
                bag.Add(index);                
            });

            Console.WriteLine("Parallel sync concurent structure ended! " + bag.Count);
        }

        public async void ParallelAsyncCycle(int num)
        {
            Console.WriteLine("Parallel async started!");

            var number = 0;
            await Task.Run(() =>
            {
                Parallel.For(0, num, (index, loopCondition) =>
                {
                    Interlocked.Increment(ref number);
                });
            });

            Console.WriteLine("Parallel async ended! " + number);
        }        

        public void ThreadAsyncCycle(int num)
        {
            Console.WriteLine("Thread async started!");

            var number = 0;
            var thread = new Thread(() =>
            {
                for (int i = 0; i < num; i++)
                {
                    number++;
                }                
            });

            thread.Start();
            thread.Join();

            Console.WriteLine("Thread async ended! " + number);
        }

        public void MultithreadAsyncCycle(int num)
        {
            Console.WriteLine("Multithreaded async started!");

            var lockObject = new object();
            var number = 0;

            var firstThread = new Thread(() =>
            {
                for (int i = 0; i < num / 2; i++)
                {
                    lock (lockObject)
                    {
                        number++;
                    }
                }
            });

            var secondThread = new Thread(() =>
            {
                for (int i = num / 2; i < num; i++)
                {
                    lock (lockObject)
                    {
                        number++;
                    }
                }
            });

            firstThread.Start();
            secondThread.Start();

            firstThread.Join();
            secondThread.Join();

            Console.WriteLine("Multithreaded async ended! " + number);
        }
    }
}
