﻿using KisiselBlog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisiselBlog.Models
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Blog> Blogs { get; set; }
    }
}
