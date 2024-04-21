using InventoriaMauiApp.Models;
using System;

namespace InventoriaMauiApp.Services
{
    public class RackUnitStateService : IRackUnitStateService
    {
        private RackUnitFlatDTO? _currentRackUnit;
        public RackUnitFlatDTO CurrentRackUnit
        {
            get => _currentRackUnit;
            set
            {
                if (_currentRackUnit != value)
                {
                    _currentRackUnit = value;
                    OnRackUnitChanged?.Invoke();
                }
            }
        }

        public event Action? OnRackUnitChanged;
    }
}
