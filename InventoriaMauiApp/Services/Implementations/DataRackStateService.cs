using InventoriaMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public class DataRackStateService : IDataRackStateService
    {
        private DataRack? _currentDataRack;
        public DataRack CurrentDataRack
        {
            get => _currentDataRack;
            set
            {
                _currentDataRack = value;
                OnDataRackChanged?.Invoke();
            }
        }

        public event Action? OnDataRackChanged;
    }

}
