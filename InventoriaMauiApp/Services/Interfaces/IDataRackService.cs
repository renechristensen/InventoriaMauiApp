using System.Collections.Generic;
using System.Threading.Tasks;
using InventoriaMauiApp.Models;

namespace InventoriaMauiApp.Services
{
    public interface IDataRackService
    {
        Task<List<DataRack>> GetAllDataRacksAsync();
        Task<DataRack> GetDataRackByIdAsync(int dataRackId);
    }
}
