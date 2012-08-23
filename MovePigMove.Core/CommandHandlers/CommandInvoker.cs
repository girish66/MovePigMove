using Raven.Client;
using StructureMap;

namespace MovePigMove.Core.CommandHandlers
{
    public class CommandInvoker : ICommandInvoker
    {
        private IContainer _container;
        private IDocumentSession _documentSession;

        public CommandInvoker(IContainer container, IDocumentSession documentSession)
        {
            _container = container;
            _documentSession = documentSession;
        }

        public void Execute<T>(T command)
        {
            var handler = _container.GetInstance<ICommandHandler<T>>();
            handler.Handle(command);
            _documentSession.SaveChanges();
        }
    }
}