using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server= EMIR; database=CoreBlogDb; integrated security=true;"); 
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Article> Articles{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Writer> Writers{ get; set; }
        public DbSet<Admin> Admins{ get; set; }

    }
}
