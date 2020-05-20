using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hapi_tests
{
    [TestClass]
    public class HelloWorldTest
    {
        [TestMethod]
        public void TestHelloWorld()
        {
            var program = new hapi.Program();
            
            Assert.AreEqual(program.GetHelloWorld(), "Hello, World!");
        }
    }
}
