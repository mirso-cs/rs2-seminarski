using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Source.net.infrastructure.Dtos
{
    public class UpdatePostDto
    {
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [Required]
        [JsonProperty("content")]
        public string Content { get; set; }

        [Required]
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [Required]
        [JsonProperty("category_id")]
        public int CategoryId{ get; set; }

        [Required]
        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [Required]
        [JsonProperty("published")]
        public bool Published { get; set; }
    }
}
