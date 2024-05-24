namespace RemoteLearning.TheUniverse.Infrastructure
{
    public interface IRequestHandler<out TResult, in TRequest>
    {
        TResult Execute(TRequest request);
    }
}