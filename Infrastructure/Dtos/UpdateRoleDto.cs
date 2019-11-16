using Infrastructure.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos
{
    public class UpdateRoleDto
    {
        [Required]
        [JsonProperty("role")]
        public Role Role { get; set; }
    }
}
