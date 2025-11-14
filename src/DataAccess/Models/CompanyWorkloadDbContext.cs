using CompanyWorkload.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyWorkload.DataAccess.Models;

public class CompanyWorkloadDbContext : DbContext
{
    public CompanyWorkloadDbContext(DbContextOptions<CompanyWorkloadDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee>      Employees      => Set<Employee>();
    public DbSet<Department>    Departments    => Set<Department>();
    public DbSet<Position>      Positions      => Set<Position>();
    public DbSet<Skill>         Skills         => Set<Skill>();
    public DbSet<EmployeeSkill> EmployeeSkills => Set<EmployeeSkill>();
    public DbSet<Project>       Projects       => Set<Project>();
    public DbSet<ProjectTask>   ProjectTasks   => Set<ProjectTask>();
    public DbSet<Assignment>    Assignments    => Set<Assignment>();
    public DbSet<WorkCalendar>  WorkCalendars  => Set<WorkCalendar>();
    public DbSet<Holiday>       Holidays       => Set<Holiday>();
    public DbSet<WorkloadRule>  WorkloadRules  => Set<WorkloadRule>();
    public DbSet<TimeEntry>     TimeEntries    => Set<TimeEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Department
        modelBuilder.Entity<Department>()
            .HasIndex(d => d.Name)
            .IsUnique();

        // Position
        modelBuilder.Entity<Position>()
            .HasIndex(p => p.Name)
            .IsUnique();

        // Employee
        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.Email)
            .IsUnique();

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Position)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.PositionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Skill
        modelBuilder.Entity<Skill>()
            .HasIndex(s => s.Name)
            .IsUnique();

        // EmployeeSkill (many-to-many)
        modelBuilder.Entity<EmployeeSkill>()
            .HasKey(es => new { es.EmployeeId, es.SkillId });

        modelBuilder.Entity<EmployeeSkill>()
            .HasOne(es => es.Employee)
            .WithMany(e => e.Skills)
            .HasForeignKey(es => es.EmployeeId);

        modelBuilder.Entity<EmployeeSkill>()
            .HasOne(es => es.Skill)
            .WithMany()
            .HasForeignKey(es => es.SkillId);

        // Project
        modelBuilder.Entity<Project>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<ProjectTask>()
            .HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId);

        // Assignment
        modelBuilder.Entity<Assignment>()
            .HasOne(a => a.Task)
            .WithMany(t => t.Assignments)
            .HasForeignKey(a => a.TaskId);

        modelBuilder.Entity<Assignment>()
            .HasOne(a => a.Employee)
            .WithMany(e => e.Assignments)
            .HasForeignKey(a => a.EmployeeId);

        // WorkCalendar
        modelBuilder.Entity<WorkCalendar>()
            .HasOne(w => w.Employee)
            .WithMany(e => e.WorkCalendars)
            .HasForeignKey(w => w.EmployeeId);

        // Holiday
        modelBuilder.Entity<Holiday>()
            .HasIndex(h => h.Day)
            .IsUnique();

        // WorkloadRule
        modelBuilder.Entity<WorkloadRule>()
            .HasIndex(r => r.Name)
            .IsUnique();

        // TimeEntry
        modelBuilder.Entity<TimeEntry>()
            .HasOne(te => te.Employee)
            .WithMany(e => e.TimeEntries)
            .HasForeignKey(te => te.EmployeeId);

        modelBuilder.Entity<TimeEntry>()
            .HasOne(te => te.Task)
            .WithMany(t => t.TimeEntries)
            .HasForeignKey(te => te.TaskId);

        // decimals
        modelBuilder.Entity<ProjectTask>()
            .Property(t => t.PlannedHours)
            .HasColumnType("numeric(10,2)");

        modelBuilder.Entity<Assignment>()
            .Property(a => a.AllocationPercent)
            .HasColumnType("numeric(5,2)");

        modelBuilder.Entity<WorkCalendar>()
            .Property(w => w.CapacityHours)
            .HasColumnType("numeric(5,2)");

        modelBuilder.Entity<WorkloadRule>()
            .Property(r => r.MaxAllocationPercent)
            .HasColumnType("numeric(5,2)");

        modelBuilder.Entity<TimeEntry>()
            .Property(t => t.SpentHours)
            .HasColumnType("numeric(10,2)");
    }
}
