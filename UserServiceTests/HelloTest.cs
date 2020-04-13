using NUnit.Framework;
using Moq;
using UserService.Controllers;
using Microsoft.Extensions.Logging;
using UserService.BLL;
using UserService.DAL;
using System.Threading.Tasks;
using UserService.DAL.Interfaces;

namespace UserServiceTests
{
    public class HelloTests
    {
        private const string Hello_World = "Hello World!";
        public HelloController helloController;
        

        [SetUp]
        public void Setup()
        {
            // Mock logger (unused, so no setup)
            var mockLogger = new Mock<ILogger<HelloController>>();

            // Create our mock HelloWorldRepo object, with explicitly defined behaviour (loose is default anyway)
            Mock<IHelloWorldRepo> mockHelloWorldRepo = new Mock<IHelloWorldRepo>(MockBehavior.Loose);
                
            // Setup Mock async get method
            mockHelloWorldRepo.Setup(arg => arg.Get())
                // Setup return type
                .Returns(Task.FromResult(Hello_World));

            // Hello object, with our mock HelloWorldRepo (class handling database connection)
            var mockHello = new Hello(mockHelloWorldRepo.Object);

            // HelloController to be used in testing, with our mock logger and our shimmed Hello object
            this.helloController = new HelloController(mockLogger.Object, mockHello);
        }

        [Test]
        public void Test_Get_Returns()
        {
            // Act
            var result = helloController.Get().Result;
            
            // Assert
            Assert.AreEqual(Hello_World, result);
        }
    }
}