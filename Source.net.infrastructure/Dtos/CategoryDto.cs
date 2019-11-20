using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Source.net.infrastructure.Dtos
{
    public class CategoryDto
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
