using MovePigMove.Core.CommandHandlers;
using MovePigMove.UI.Infrastructure.StructureMap.Conventions;
using Raven.Client;
using Raven.Client.Embedded;
using StructureMap.Configuration.DSL;

namespace MovePigMove.Core.StructureMap
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry(IDocumentStore docStore)
        {
            Scan(scan =>
                {
                    scan.AssembliesFromApplicationBaseDirectory(x => x.FullName.StartsWith("MovePigMove"));
                    scan.With(new RegisterGenericTypesOfInterface(typeof(IViewFactory<,>)));
                    scan.With(new RegisterGenericTypesOfInterface(typeof(ICommandHandler<>)));
                    //scan.With(new RegisterGenericTypesOfInterface(typeof(IValidator<>)));
                    //scan.With(new RegisterGenericTypesOfInterface(typeof(IModelBinder<>)));
                    scan.With(new RegisterFirstInstanceOfInterface());
                });

            For<IDocumentStore>().Use(docStore);
            For<IDocumentSession>()
                .HybridHttpOrThreadLocalScoped()
                .Use(x =>
                {
                    var store = x.GetInstance<IDocumentStore>();
                    return store.OpenSession();
                });
        }
    }
}