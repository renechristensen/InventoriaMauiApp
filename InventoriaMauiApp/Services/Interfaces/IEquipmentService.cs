using InventoriaMauiApp.Models;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public interface IEquipmentService
    {
        Task<EquipmentDTO> GetEquipmentById(int equipmentId);
        Task<EquipmentDTO> CreateEquipment(CreateEquipmentDTO equipment);
        Task<bool> UpdateEquipment(int equipmentId, UpdateEquipmentDTO equipment);
        Task<bool> DeleteEquipment(int equipmentId);
    }
}
