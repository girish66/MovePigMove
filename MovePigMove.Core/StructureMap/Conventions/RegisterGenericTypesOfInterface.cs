using System;
using System.Linq;
using StructureMap.Graph;

namespace MovePigMove.UI.Infrastructure.StructureMap.Conventions
{
    public class RegisterGenericTypesOfInterface : IRegistrationConvention
    {
        private readonly Type _baseInterface;

        public RegisterGenericTypesOfInterface(Type baseInterface)
        {
            this._baseInterface = baseInterface;
        }
        public void Process(Type type, global::StructureMap.Configuration.DSL.Registry registry)
        {
            if (type.IsAbstract) { return; }
            if (type.IsInterface) { return; }
            var originalInterface = type.GetInterfaces().FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == _baseInterface);
            if (originalInterface == null) return;

            Type[] wrappedTypes = originalInterface.GetGenericArguments();

            // Create the created type
            Type implementationType = _baseInterface.MakeGenericType(wrappedTypes);

            // And specify what we're going to use
            registry.For(implementationType).Use(type);

        }


    }
}