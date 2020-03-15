﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.net.mobile.ViewModels
{
    public class PostGridItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public string Thumbnail { get; set; }
        public bool Published { get; set; }
    }
}
