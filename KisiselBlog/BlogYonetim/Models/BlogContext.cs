using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogYonetim.Models
{
    public class BlogContext:DbContext
    {



        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

            //contr

        }



        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Blog> Blog { get; set; }


    }
}
