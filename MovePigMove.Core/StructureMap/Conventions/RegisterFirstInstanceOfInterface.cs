using System;
using System.Linq;
using System.Reflection;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace MovePigMove.UI.Infrastructure.StructureMap.Conventions
{
    public class RegisterFirstInstanceOfInterface : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (!type.IsInterface) { return; }
            if (type.IsGenericTypeDefinition) { return; }

            Assembly containingAssembly = type.Assembly;
            
            var matchedType = containingAssembly
                                    .GetTypes()
                                    .FirstOrDefault(x => x.Namespace == type.Namespace
                                                         && x.GetInterface(type.FullName) != null);
            if (matchedType == null) { return; }

            registry.For(type).Use(matchedType);
        }
    }
}