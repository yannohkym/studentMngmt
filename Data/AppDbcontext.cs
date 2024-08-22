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

    
            public DbSet<Student> Students { get; set; }

            public DbSet<ClassStream> ClassStream { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

           

            // Additional configurations (if any)
          


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder.Entity<ClassStream>()
                .HasKey(cs => cs.Id);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.ClassStream)
                .WithMany(cs => cs.Students)
                .HasForeignKey(s => s.Id);



            // seeder
            modelBuilder.Entity<ClassStream>().HasData(
            new ClassStream { Id = 1, Name = "Form1", Description = "Science Stream" },
            new ClassStream { Id = 2, Name = " Form 2", Description = "Arts Stream" },
            new ClassStream { Id = 3, Name = "Form 3", Description = "Commerce Stream" },
            new ClassStream { Id = 4, Name = "Form 4", Description = "Technical Stream" }
            );

            modelBuilder.Entity<Student>().HasData(
            new Student { StudentId = 1, FirstName = "John ", LastName = "Doe", Age = 16, Id = 1 },
            new Student { StudentId = 2, FirstName = "Jane Doe", LastName = "Doe", Age = 17, Id = 2 },
            new Student { StudentId = 3, FirstName = "Jim ", LastName = "Doe", Age = 16, Id = 3 }
            );


         
    }
    }
    
}
