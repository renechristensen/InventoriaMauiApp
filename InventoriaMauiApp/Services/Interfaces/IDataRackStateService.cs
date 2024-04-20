using InventoriaMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public interface IDataRackStateService
    {
        DataRack CurrentDataRack { get; set; }
        event Action OnDataRackChanged;
    }
}
