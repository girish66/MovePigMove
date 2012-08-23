namespace MovePigMove.Core
{
    public interface IViewFactory<TInput, TOutput>
    {
        TOutput Load(TInput input);
    }
}