using StructureMap;

namespace MovePigMove.Core.ViewModels
{
    public class ViewRepository : IViewRepository
    {
        private IContainer _container;

        public ViewRepository(IContainer container)
        {
            _container = container;
        }

        public TOutput Load<TInput, TOutput>(TInput input)
        {
            var factory = _container.TryGetInstance<IViewFactory<TInput, TOutput>>();
            if (factory == null) return default(TOutput);
            return factory.Load(input);
        }
    }
}