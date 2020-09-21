using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using House.HLL.Dashboard.Bindicator.Models;

namespace HouseTests
{
    [TestFixture]
    public class Bindicator
    {

        private Mock<IBindicatorProvider> _bindicatorProvider;

        [SetUp]
        public void Setup()
        {
            _bindicatorProvider = new Mock<IBindicatorProvider>();
            _bindicatorProvider.Setup(x=>x.Get()).ReturnsAsync(new BinLookup(new BinLookupDto()))
        }

        [Test]
        public Task Get()
        {
            Assert.IsInstanceOf(BinLookup, BinLookup);
        }
    }
}