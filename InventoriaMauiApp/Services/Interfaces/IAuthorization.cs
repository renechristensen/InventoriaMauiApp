using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public interface IAuthorizationService
    {
        Task<string> GetAuthorizationTokenAsync();
    }
}

