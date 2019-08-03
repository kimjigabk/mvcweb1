using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Dtos
{
    public class MusicDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }

        [Required]
        public string YoutubeUrl { get; set; }

        public string Description { get; set; }
    }
}