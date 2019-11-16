using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos
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
