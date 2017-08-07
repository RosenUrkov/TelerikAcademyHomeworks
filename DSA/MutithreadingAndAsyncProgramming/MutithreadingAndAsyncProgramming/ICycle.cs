namespace MutithreadingAndAsyncProgramming
{
    public interface ICycles
    {
        void StartCycling(int number);

        void SyncCycle(int number);

        void AsyncCycle(int number);

        void ParallelSyncCycle(int number);

        void ParallelSyncConcurentStructureCycle(int number);

        void ParallelAsyncCycle(int number);

        void ThreadAsyncCycle(int number);

        void MultithreadAsyncCycle(int number);
    }
}
