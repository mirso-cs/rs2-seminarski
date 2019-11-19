using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Source.net.infrastructure.Dtos
{
    public class UpdatePasswordDto
    {
        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }

        [Required]
        [JsonProperty("password_confirmation")]
        public string PassowrdConfirmation { get; set; }
    }
}
