﻿using InventoriaMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Services
{
    public interface IUserService
    {
        Task<String> LoginAsync(string username, string password);
        Task<string> RegisterUserAsync(User newUser);
        Task<User> GetUserByIdAsync(string userId);

    }
}