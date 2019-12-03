
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Context
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
       
        public DbSet<Role> Roles { get; set; }

        public DbSet<Privilege> Prevlages { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<RolePrivilege> RolePrivilege { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
        .HasKey(i => new { i.UserId, i.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(i => i.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(i => i.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(i => i.Role)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(i => i.RoleId);

            modelBuilder.Entity<RolePrivilege>()
        .HasKey(i => new { i.RoleId, i.PrevillageId });
            modelBuilder.Entity<RolePrivilege>()
                .HasOne(i => i.Role)
                .WithMany(b => b.RolePrivilege)
                .HasForeignKey(i => i.RoleId);
            modelBuilder.Entity<RolePrivilege>()
                .HasOne(i => i.Prevlages)
                .WithMany(c => c.RolePrivilege)
                .HasForeignKey(i => i.PrevillageId);

        }

        public virtual int Save()
        {
           return base.SaveChanges();
        }
      
    }
}
