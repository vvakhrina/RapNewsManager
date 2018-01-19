using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RapNewsManager.Models
{
    public class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<Habilitation> Habilitation { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<User_Functions> User_Functions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habilitation>()
                .Property(e => e.function_name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.role_name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name_user)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();
        }

        public System.Data.Entity.DbSet<RapNewsManager.Models.News> News { get; set; }
    }
}
