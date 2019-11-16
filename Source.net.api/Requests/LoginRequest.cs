using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Source.net.api.Requests
{
    public class LoginRequest
    {
        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }


        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
