using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Source.net.infrastructure.Dtos
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
