namespace UserServiceTests
{
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using House.Controllers;

    public class HelloTests
    {
        private const string Hello_World = "Hello World!";

        public HelloController HelloController { get; set; }

        [SetUp]
        public void Setup()
        {
            // Mock logger (unused, so no setup)
            var mockLogger = new Mock<ILogger<HelloController>>();

            // Create our mock HelloWorldRepo object, with explicitly defined behaviour (loose is default anyway)
            var mockHelloWorldRepo = new Mock<IHelloWorldRepo>(MockBehavior.Loose);

            // Setup Mock async get method
            mockHelloWorldRepo.Setup(repo => repo.Get())
                // Setup return type
                .Returns(Task.FromResult(Hello_World));

            // Hello object, with our mock HelloWorldRepo (class handling database connection)
            var mockHello = new Hello(mockHelloWorldRepo.Object);

            // HelloController to be used in testing, with our mock logger and our shimmed Hello object
            this.HelloController = new HelloController(mockLogger.Object, mockHello);
        }

        [Test]
        public void Test_Get_Returns()
        {
            // Act
            string result = this.HelloController.Get().Result;

            // Assert
            Assert.AreEqual(Hello_World, result);
        }
    }
}