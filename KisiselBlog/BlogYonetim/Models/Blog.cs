using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogYonetim.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public bool IsPublish { get; set; }
        public Author Author { get; set; }
        public int Authorid { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }




    }
}
