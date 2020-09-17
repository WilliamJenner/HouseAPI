namespace House.BLL
{
    using System.Threading.Tasks;
    using House.BLL.Interfaces;
    using House.DAL.Interfaces;
    using House;

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
