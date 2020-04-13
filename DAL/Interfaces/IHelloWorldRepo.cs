using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserService.DAL.Interfaces
{
    public interface IHelloWorldRepo
    {
        Task<string> Get();
    }
}
