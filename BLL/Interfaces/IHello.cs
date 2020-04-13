using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserService.BLL.Interfaces
{
    public interface IHello
    {
        Task<string> Get();
    }
}
