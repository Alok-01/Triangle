using CS.Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Contracts
{
    public interface IAuthenticationManager
    {
        Task<bool> ValdiateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
