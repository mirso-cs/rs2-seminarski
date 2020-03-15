using System;
using System.Collections.Generic;
using System.Text;

namespace Source.net.infrastructure.Dtos
{
    public class RatingDto
    {
        public int PostId { get; set; }
        public int userId { get; set; }
        public int Rating { get; set; }
    }
}
