using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos
{
    public class RegisterDto
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("surname")]
        public string Surname { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
