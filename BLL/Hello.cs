using System.Threading.Tasks;
using UserService.BLL.Interfaces;
using UserService.DAL.Interfaces;

namespace UserService.BLL
{
    public class Hello : IHello
    {
        private readonly IHelloWorldRepo _helloWorldRepo;

        public Hello(IHelloWorldRepo helloWorldRepo)
        {
            _helloWorldRepo = helloWorldRepo;
        }

        public async Task<string> Get()
        {
            return await _helloWorldRepo.Get();
        }
    }
}
