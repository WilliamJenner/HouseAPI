namespace UserService.BLL.Interfaces
{
    using System.Threading.Tasks;

    public interface IHello
    {
        Task<string> Get();
    }
}
