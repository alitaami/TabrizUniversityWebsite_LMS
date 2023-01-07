using Institue.DataLayer.Entities.Lesson;
using Institue.DataLayer.Entities.Permission;
using Institue.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Institue.DataLayer.Context
{
    public class InstitueContext : DbContext
    {
        public InstitueContext(DbContextOptions<InstitueContext> options) : base(options)
        {


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonDetail> LessonDetails { get; set; }
        public DbSet<UserLesson> UserLessons { get; set; }
        public DbSet<UserMajors> UserMajors { get; set; }
        public DbSet<LessonMajors> LessonMajors { get; set; }
        public DbSet<LessonPractice> LessonPractice { get; set; }
        public DbSet<LessonProject> LessonProject { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetForeignKeys())
               .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            //modelBuilder.Entity<Lesson>()
            // .HasOne<Major>(c => c.Major)
            // .WithMany(cg => cg.Lessons)
            // .HasForeignKey(fk => fk.MajorId);
            ////modelBuilder.Entity<User>()
            //.HasOne<Major>(c => c.Major)
            //.WithMany(cg => cg.Users)
            //.HasForeignKey(fk => fk.MajorId);

 

            base.OnModelCreating(modelBuilder);

        }
    }
}
