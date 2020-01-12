using System.Collections.Generic;

namespace Source.net.infrastructure.Views
{
    public class PostView
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public ICollection<TagView> Tags { get; set; }
        public bool Published { get; set; }
    }
}
