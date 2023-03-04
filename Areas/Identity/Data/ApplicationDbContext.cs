// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;

// namespace NSCCCourseMap.Data;

// public class ApplicationDbContext : IdentityDbContext<IdentityUser>
// {
//     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//         : base(options)
//     {
//     }

//         public DbSet<NSCCCourseMap.Models.Diploma> Diplomas { get; set; } = default!; // Table
//         public DbSet<NSCCCourseMap.Models.Instructor> Instructors { get; set; } = default!; // Table
//         public DbSet<NSCCCourseMap.Models.AcademicYear> AcademicYears { get; set; } = default!; // Table
//         public DbSet<NSCCCourseMap.Models.Course> Courses { get; set; } = default!; // Table
//         public DbSet<NSCCCourseMap.Models.DiplomaYear> DiplomaYears { get; set; } = default!; // Table
//         public DbSet<NSCCCourseMap.Models.DiplomaYearSection> DiplomaYearSections { get; set; } = default!; // Table
//         public DbSet<NSCCCourseMap.Models.Semester> Semesters { get; set; } = default!; // Table
//         public DbSet<NSCCCourseMap.Models.AdvisingAssignment> AdvisingAssignments { get; set; } = default!; // Table
//         public DbSet<NSCCCourseMap.Models.CourseOffering> CourseOfferings { get; set; } = default!; // Table
//         public DbSet<NSCCCourseMap.Models.CoursePrerequisite> CoursePrerequisites { get; set; } = default!; // Table

//     // protected override void OnModelCreating(ModelBuilder builder)
//     // {
//     //     base.OnModelCreating(builder);
//     //     // Customize the ASP.NET Identity model and override the defaults if needed.
//     //     // For example, you can rename the ASP.NET Identity table names and more.
//     //     // Add your customizations after calling base.OnModelCreating(builder);
//     // }
//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//         //Write Fluent API configurations here
//             modelBuilder.Entity<Models.Diploma>().HasIndex(d => d.Title).IsUnique();
//             {
//                 // RECONCILE THE MANY TO MANY RECURSIVE (VERSION 1)
//                 // modelBuilder.Entity<Course>()
//                 //     .HasMany(c => c.Prerequisites)
//                 //     .WithOne(cpr => cpr.Courses)
//                 //     .HasForeignKey(cpr => cpr.CourseId);
//                 // modelBuilder.Entity<Models.Course>()
//                 //     .HasMany(c => c.IsPrerequisiteFor)
//                 //     .WithOne(cpr => cpr.Prerequisites)
//                 //     .HasForeignKey(cpr => cpr.PrerequisiteId);

//                 // // RECONCILE THE MANY TO MANY RECURSIVE (VERSION 2)
//                 // modelBuilder.Entity<Course>()
//                 // .HasMany(c => c.Prerequisites)
//                 // .WithMany(c => c.IsPrerequisiteFor);

//                 // TURN OFF CASCADE DELETE FOR ALL RELATIONSHIPS
//                 foreach(var entity in modelBuilder.Model.GetEntityTypes())
//                 {
//                     foreach(var fk in entity.GetForeignKeys()){
//                         fk.DeleteBehavior = DeleteBehavior.NoAction;
//                     }
//                 }
//             }
//         }
// }
