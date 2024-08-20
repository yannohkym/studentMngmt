using Student__management__system.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Student__management__system.Data
{
  

        public class AppDbcontext : DbContext
        {
            public AppDbcontext(DbContextOptions<AppDbcontext> options)
                : base(options)
            {
            }

            public DbSet<Streams> Streams { get; set; }
            public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Streams>()
                .HasKey(s => s.StreamId); 

            // Additional configurations (if any)
            modelBuilder.Entity<Student>()
               .HasKey(s => s.StudentId);
        }
    }
    
}
