﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoriaMauiApp.Models
{
        public class AuthResponse
        {
            [JsonProperty("login")]
            public User Login { get; set; }

            [JsonProperty("token")]
            public string Token { get; set; }
        }
}
