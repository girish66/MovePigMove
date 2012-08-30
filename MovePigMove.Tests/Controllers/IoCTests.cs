using System.Linq;
using Moq;
using MovePigMove.Core.StructureMap;
using MovePigMove.Web.Controllers;
using NUnit.Framework;
using Raven.Client;
using StructureMap;

namespace MovePigMove.Tests.Controllers
{
    [TestFixture]
    [Explicit("Takes a few seconds longer than i want")]
    public class IoCTests
    {
        [Test]
        public void CanResolveAllControllersViaIoC()
        {
            var controllers = typeof (BaseController)
                                .Assembly
                                .GetTypes()
                                .Where(x => //typeof (BaseController).IsAssignableFrom(x) && 
                                            x.IsSubclassOf(typeof(BaseController)) &&
                                            x.IsAbstract == false);

                var documentStore = new Mock<IDocumentStore>();

                ObjectFactory.Initialize(a => a.AddRegistry(new ApplicationRegistry(documentStore.Object)));

                foreach (var controller in controllers)
                {
                    try
                    {
                        var resolved = ObjectFactory.GetInstance(controller);

                        if (resolved == null)
                        {
                            Assert.Fail("Could not resolve controller " + controller.FullName);
                        }

                    }
                    catch 
                    {
                        System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());

                        throw;
                    }
                }
        }
    }


}