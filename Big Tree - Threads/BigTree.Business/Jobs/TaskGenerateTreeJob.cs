using iQuest.BigTree.ThirdPartyLibrary;
using System;
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
            Node node = new Node
            {
                Values = ThirdPartyCalculator.Calculate()
            };

            if (descendentLevelCount > 0)
            {
                Task<Node> leftTask = Task.Run(() => GenerateNode(descendentLevelCount - 1));
                Task<Node> rightTask = Task.Run(() => GenerateNode(descendentLevelCount - 1));
                Task.WaitAll(leftTask, rightTask);
                node.LeftNode = leftTask.Result;
                node.RightNode = rightTask.Result;
            }

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
