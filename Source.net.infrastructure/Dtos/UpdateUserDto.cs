using Source.net.infrastructure.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Source.net.infrastructure.Dtos
{
    public class UpdateUserDto
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
    }
}
