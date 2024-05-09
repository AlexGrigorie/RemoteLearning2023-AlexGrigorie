using iQuest.BigTree.ThirdPartyLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace iQuest.BigTree.Business.Jobs
{
    internal class TaskGenerateTreeJob : IJob
    {
        public int LevelCount { get; set; }

        public string Description { get; } = "Multithreading generation";

        public JobResult Execute()
        {
            Node tree = null;

            TimeSpan elapsedTime = MeasureExecutionTime(() =>{ tree = GenerateNode(LevelCount - 1); });

            return new JobResult
            {
                Tree = tree,
                ElapsedTime = elapsedTime
            };
        }

        private static Node GenerateNode(int descendentLevelCount)
        {
            List<Task> tasks = new List<Task>();
            Node node = new Node();
            Task task = Task.Run(() => node.Values = ThirdPartyCalculator.Calculate());
            tasks.Add(task);

            if (descendentLevelCount > 0)
            {
                node.LeftNode = GenerateNode(descendentLevelCount - 1);
                node.RightNode = GenerateNode(descendentLevelCount - 1);
            }
            Task.WhenAll(tasks);
            return node;
        }

        private static TimeSpan MeasureExecutionTime(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            return stopwatch.Elapsed;
        }
    }
}
