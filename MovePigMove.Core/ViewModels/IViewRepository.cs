namespace MovePigMove.Core.ViewModels
{
    public interface IViewRepository
    {
        TOutput Load<TInput, TOutput>(TInput input);
    }
}