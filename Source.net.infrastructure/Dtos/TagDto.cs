using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Source.net.infrastructure.Dtos
{
    public class TagDto
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
