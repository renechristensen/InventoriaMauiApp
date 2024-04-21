using InventoriaMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public class UserStateService : IUserStateService
    {
        private User? _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnUserChanged?.Invoke();
            }
        }

        public event Action? OnUserChanged;
    }

}
