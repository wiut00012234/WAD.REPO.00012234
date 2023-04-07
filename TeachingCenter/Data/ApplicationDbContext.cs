using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeachingCenter.Models;

namespace TeachingCenter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EBook> EBooks { get; set; }
        public DbSet<ExamDate> ExamDates { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<TeachingCenter.Models.Student> Student { get; set; }
    }
}
