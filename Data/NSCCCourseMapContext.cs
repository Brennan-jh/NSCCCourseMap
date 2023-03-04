using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Models;

namespace NSCCCourseMap.Data
{
    public class NSCCCourseMapContext : IdentityDbContext<IdentityUser> // database
    {
        // construcor
        public NSCCCourseMapContext (DbContextOptions<NSCCCourseMapContext> options)
            : base(options)
        {
        }

        public DbSet<NSCCCourseMap.Models.Diploma> Diplomas { get; set; } = default!; // Table
        public DbSet<NSCCCourseMap.Models.Instructor> Instructors { get; set; } = default!; // Table
        public DbSet<NSCCCourseMap.Models.AcademicYear> AcademicYears { get; set; } = default!; // Table
        public DbSet<NSCCCourseMap.Models.Course> Courses { get; set; } = default!; // Table
        public DbSet<NSCCCourseMap.Models.DiplomaYear> DiplomaYears { get; set; } = default!; // Table
        public DbSet<NSCCCourseMap.Models.DiplomaYearSection> DiplomaYearSections { get; set; } = default!; // Table
        public DbSet<NSCCCourseMap.Models.Semester> Semesters { get; set; } = default!; // Table
        public DbSet<NSCCCourseMap.Models.AdvisingAssignment> AdvisingAssignments { get; set; } = default!; // Table
        public DbSet<NSCCCourseMap.Models.CourseOffering> CourseOfferings { get; set; } = default!; // Table
        public DbSet<NSCCCourseMap.Models.CoursePrerequisite> CoursePrerequisites { get; set; } = default!; // Table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        //Write Fluent API configurations here
            modelBuilder.Entity<Models.Diploma>().HasIndex(d => d.Title).IsUnique();
            {
                // RECONCILE THE MANY TO MANY RECURSIVE (VERSION 1)
                modelBuilder.Entity<Course>()
                    .HasMany(c => c.Prerequisites)
                    .WithOne(cpr => cpr.Courses)
                    .HasForeignKey(cpr => cpr.CourseId);
                modelBuilder.Entity<Models.Course>()
                    .HasMany(c => c.IsPrerequisiteFor)
                    .WithOne(cpr => cpr.Prerequisites)
                    .HasForeignKey(cpr => cpr.PrerequisiteId);

                // // RECONCILE THE MANY TO MANY RECURSIVE (VERSION 2)
                // modelBuilder.Entity<Course>()
                // .HasMany(c => c.Prerequisites)
                // .WithMany(c => c.IsPrerequisiteFor);

                // TURN OFF CASCADE DELETE FOR ALL RELATIONSHIPS
                foreach(var entity in modelBuilder.Model.GetEntityTypes())
                {
                    foreach(var fk in entity.GetForeignKeys()){
                        fk.DeleteBehavior = DeleteBehavior.NoAction;
                    }
                }
            }
        }
    }
}