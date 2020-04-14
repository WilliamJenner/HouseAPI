namespace UserService.BLL
{
    using System.Threading.Tasks;
    using UserService.BLL.Interfaces;
    using UserService.DAL.Interfaces;

    public class Hello : IHello
    {
        private readonly IHelloWorldRepo _helloWorldRepo;

        public Hello(IHelloWorldRepo helloWorldRepo)
        {
            this._helloWorldRepo = helloWorldRepo;
        }

        public async Task<string> Get()
        {
            return await this._helloWorldRepo.Get();
        }
    }
}
