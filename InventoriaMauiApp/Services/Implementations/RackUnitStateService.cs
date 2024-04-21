using InventoriaMauiApp.Models;
using System;
using System.Collections.Generic;

namespace InventoriaMauiApp.Services
{
    public class RackUnitStateService : IRackUnitStateService
    {
        private RackUnitFlatDTO _currentRackUnit;
        private HashSet<int> _selectedRackUnitIds = new HashSet<int>();

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

        public HashSet<int> SelectedRackUnitIds
        {
            get => _selectedRackUnitIds;
            set
            {
                if (_selectedRackUnitIds != value)
                {
                    _selectedRackUnitIds = value;
                    OnRackUnitChanged?.Invoke();
                }
            }
        }

        public event Action OnRackUnitChanged;
    }
}
