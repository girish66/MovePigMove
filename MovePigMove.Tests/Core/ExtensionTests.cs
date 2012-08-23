using MovePigMove.Core;
using NUnit.Framework;
using Should;

namespace MovePigMove.Tests.Core
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void GetsAfterLastWhenSearchExists()
        {
            "something/12".AfterLast("/").ShouldEqual("12");
            "something/12".AfterLast(@"/").ShouldEqual("12");
        }

        [Test]
        public void ReturnsEntireStringIfThereIsNoMatch()
        {
            "something/12".AfterLast(@"\").ShouldEqual("something/12");
        }
    }
}