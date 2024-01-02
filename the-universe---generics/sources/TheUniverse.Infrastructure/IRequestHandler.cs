namespace RemoteLearning.TheUniverse.Infrastructure
{
    public interface IRequestHandler<TResult, TRequest>
    {
        TResult Execute(TRequest request);
    }
}