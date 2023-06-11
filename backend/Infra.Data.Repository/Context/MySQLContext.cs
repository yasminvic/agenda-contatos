using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new {Id = 1, Login = "aninha", Password = "123"},
                    new {Id = 2, Login = "pedrosilva", Password = "123"},
                    new {Id = 3, Login = "rafa", Password = "123"}
                );

            modelBuilder.Entity<Contact>()
                .HasData(
                    new {Id = 1, UserId = 1, Name = "Júlia Andrade", PhoneNumber = "47999887766", Email = "juh@gmail.com"},
                    new { Id = 2, UserId = 1, Name = "Maria de Souza", PhoneNumber = "47988554411", Email = "maria@gmail.com" },
                    new { Id = 3, UserId = 2, Name = "Lucas Cardoso", PhoneNumber = "47998527413", Email = "lucas@gmail.com" },
                    new { Id = 4, UserId = 2, Name = "Matheus Varella", PhoneNumber = "47996745210", Email = "matheus@gmail.com" },
                    new { Id = 5, UserId = 3, Name = "Ricardo Krueger", PhoneNumber = "47988567942", Email = "ricardo@gmail.com" }
                );
        }

        #region DbSets
        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }
        #endregion
    }
}
