namespace House.DAL
{
    using System.Threading.Tasks;
    using Dapper;
    using Interfaces;

    public class HelloWorldRepo : BaseRepository, IHelloWorldRepo
    {

        public HelloWorldRepo(ConnectionStrings connectionStrings) : base(connectionStrings.WeeklyDigest)
        {
        }

        public async Task<string> Get()
        {
            return await Task.FromResult("Hello");
        }
    }
}
