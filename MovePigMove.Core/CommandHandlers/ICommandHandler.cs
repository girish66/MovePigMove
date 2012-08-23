namespace MovePigMove.Core.CommandHandlers
{
    public interface ICommandHandler<T>
    {
        void Handle(T command);
    }
}