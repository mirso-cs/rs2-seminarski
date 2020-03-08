using System;
using System.Collections.Generic;
using System.Text;

namespace Source.net.infrastructure.SearchFilters
{
    public class PostFilters
    {
        public string Title { get; set; }
        public string Tag { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }
        public string Category { get; set; }
        public bool OnlyPublished { get; set; }
        public bool OnlyUnpublished { get; set; }
    }
}
