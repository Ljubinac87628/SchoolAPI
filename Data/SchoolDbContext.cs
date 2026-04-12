using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Final> Finals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(new Course { Id = 1, Name = "Microsoft Web Service", NumberOfClases = 32 });
            modelBuilder.Entity<Course>().HasData(new Course { Id = 2, Name = "ASP.NET Core MVC", NumberOfClases = 44 });
            modelBuilder.Entity<Course>().HasData(new Course { Id = 3, Name = "Introduction to Web Development", NumberOfClases = 32 });

            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Microsoft Web Development" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "Microsoft Desktop Development" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 3, Name = "Microsoft Database Development" });
            
                

            modelBuilder.Entity<Student>().HasData(new Student { Id = 1, FirstName = "John", LastName = "Doe ", DepartmentId = 2 });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 2, FirstName = "Mira", LastName = "Doe", DepartmentId = 1 });

            modelBuilder.Entity<Final>().HasData(new Final { Id = 1, Name = "Primer polaganja", Mark = 10, Date = DateTime.Now, CourseId = 1, StudentId = 1 });
            modelBuilder.Entity<Final>().HasData(new Final { Id = 2, Name = "Primer polaganja2", Mark = 10, Date = DateTime.Now, CourseId = 2, StudentId = 2 });
            modelBuilder.Entity<Final>().HasData(new Final { Id = 3, Name = "Primer polaganja3", Mark = 10, Date = DateTime.Now, CourseId = 3, StudentId = 3 });

        }
    }
}
