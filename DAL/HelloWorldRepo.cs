namespace UserService.DAL
{
    using System.Threading.Tasks;
    using Dapper;
    using UserService.DAL.Interfaces;

    public class HelloWorldRepo : BaseRepository, IHelloWorldRepo
    {
        public HelloWorldRepo()
            : base()
        {
        }

        public async Task<string> Get()
        {
            return await this.QueryAsync(async c => await c.QuerySingleOrDefaultAsync<string>("SELECT 'HELLO WORLD'"));
        }
    }
}
