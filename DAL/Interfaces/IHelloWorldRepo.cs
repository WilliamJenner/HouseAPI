namespace House.DAL.Interfaces
{
    using System.Threading.Tasks;

    public interface IHelloWorldRepo
    {
        Task<string> Get();
    }
}
