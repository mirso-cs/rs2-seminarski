using Source.net.infrastructure.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Source.net.infrastructure.Dtos
{
    public class UpdateRoleDto
    {
        [Required]
        [JsonProperty("role")]
        public Role Role { get; set; }
    }
}
