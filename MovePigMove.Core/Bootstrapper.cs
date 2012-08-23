using System;
using MovePigMove.Core.CommandHandlers;
using MovePigMove.Core.Documents;
using MovePigMove.Core.StructureMap;
using MovePigMove.UI.Infrastructure.StructureMap.Conventions;
using Raven.Client;
using Raven.Client.Converters;
using Raven.Client.Embedded;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace MovePigMove.Core
{
    public class Bootstrapper
    {
        public static void Start()
        {
            var docStore = new EmbeddableDocumentStore
                {
                    DataDirectory = "App_Data",
                    UseEmbeddedHttpServer = true,
                };

            docStore.Configuration.Port = 9595;

            docStore.Initialize();

            //docStore.Conventions.IdentityTypeConvertors.Add(new DocumentIdIdentityTypeConverter());
            
            ObjectFactory.Initialize(config => config.AddRegistry(new ApplicationRegistry(docStore)));


        }
    }

    //public class DocumentIdIdentityTypeConverter : ITypeConverter
    //{
    //    public bool CanConvertFrom(Type sourceType)
    //    {
    //        return sourceType == typeof (DocumentId);
    //    }

    //    public string ConvertFrom(string tag, object value, bool allowNull)
    //    {
    //        if ((DocumentId)value == string.Empty && allowNull)
    //        {
    //            return (string) null;
    //        }
    //        else
    //        {
    //            return tag + (DocumentId) value;
    //        }
    //    }

    //    public object ConvertTo(string value)
    //    {
    //        return (object) new DocumentId(value);
    //    }
    //}
    
}