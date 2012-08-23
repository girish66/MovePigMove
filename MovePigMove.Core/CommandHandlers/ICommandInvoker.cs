namespace MovePigMove.Core.CommandHandlers
{
    public interface ICommandInvoker
    {
        void Execute<T>(T command);

    }
}