using System;
using System.Collections.Generic;
using System.Linq;
using University.Persistense.UniversityDb.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Students.Models;
using University.Core.Domain.Departments.Models;
using University.Core.Domain.Faculties.Models;
using University.Core.Domain.Groups.Models;
using University.Persistence.UniversityDb.EntityConfigurations;

namespace University.Persistence.UniversityDb;

public class UniversityDbContext(DbContextOptions<UniversityDbContext> options) : DbContext(options)
{

    public static string UniversityDbSchema = "university";

    public static string UniversityMigrationHistory = "MigrationHistory";
    public DbSet<Student> Students { get; set; }

    public DbSet<Group> Groups { get; set; }

    public DbSet<Faculty> Faculties { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<FacultyDepartment> FacultyDepartments { get; set; }
    public DbSet<DepartmentGroup> DepartmentGroups { get; set; }
    public DbSet<GroupStudent> GroupStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // todo: do it only for local development
        optionsBuilder.LogTo(Console.WriteLine);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(UniversityDbSchema);
        //modelBuilder.ApplyConfigurationsFromAssembly()
        modelBuilder.ApplyConfiguration(new StudentEntityConfigurations());
        modelBuilder.ApplyConfiguration(new GroupEntityConfiguration());
        modelBuilder.ApplyConfiguration(new FacultyEntityConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentGroupEntityConfiguration());
        modelBuilder.ApplyConfiguration(new GroupStudentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new FacultyDepartmentEntityConfiguration());
    }
}


