﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos
{
    public class LoginDto
    {
        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
