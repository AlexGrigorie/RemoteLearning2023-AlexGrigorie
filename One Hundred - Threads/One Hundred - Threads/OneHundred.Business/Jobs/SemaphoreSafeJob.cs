using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System;

namespace iQuest.OneHundred.Business.Jobs
{
    internal class SemaphoreSafeJob : IJob
    {
        private long value;
        private SemaphoreSlim semaphore;

        public ushort ThreadCount { get; set; }

        public ulong IncrementCount { get; set; }

        public string Description { get; } = "Incrementing the value using Semaphore synchronization mechanism.";
        public SemaphoreSafeJob()
        {
            semaphore = new SemaphoreSlim(1, 100);
        }

        public JobResult Execute()
        {
            value = 0;
            TimeSpan elapsedTime = MeasureExecutionTime(RunAllThreads);

            return new JobResult
            {
                Value = value,
                ElapsedTime = elapsedTime
            };
        }

        private void RunAllThreads()
        {
            List<Thread> threads = Enumerable.Range(0, ThreadCount)
                .Select(x => StartNewThread())
                .ToList();

            foreach (Thread thread in threads)
                thread.Join();
        }

        private Thread StartNewThread()
        {
            Thread thread = new Thread(o =>
            {
                for (ulong i = 0; i < IncrementCount; i++)
                {
                    semaphore.Wait();
                    try
                    {
                        value++;
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }
            });

            thread.Start();

            return thread;
        }

        private static TimeSpan MeasureExecutionTime(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            return stopwatch.Elapsed;
        }
    }
}
