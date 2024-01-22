using System.Diagnostics;

namespace BoxingUnboxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            List<object> withBoxingList = new List<object>();

            for (int j = 1; j < 10000000; j++)
            {
                withBoxingList.Add(j);
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Stopwatch stopWatchNoBoxing = new Stopwatch();
            stopWatchNoBoxing.Start();
            List<int> noBoxingList = new List<int>();

            for (int j = 1; j < 10000000; j++)
            {
                noBoxingList.Add(j);
            }

            stopWatchNoBoxing.Stop();
            TimeSpan tsNoBoxing = stopWatchNoBoxing.Elapsed;

            string elapsedTimeNoBoxing = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                tsNoBoxing.Hours, tsNoBoxing.Minutes, tsNoBoxing.Seconds,
                tsNoBoxing.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTimeNoBoxing);
        }
    }
}
