using Dapper;
using System.Threading.Tasks;
using UserService.DAL.Interfaces;

namespace UserService.DAL
{
    public class HelloWorldRepo : BaseRepository, IHelloWorldRepo
    {
        

        public HelloWorldRepo() : base()
        {
           
        }

        public async Task<string> Get()
        {
            return await QueryAsync(async c => await c.QuerySingleOrDefaultAsync<string>("SELECT 'HELLO WORLD'"));
        }
    }
}
