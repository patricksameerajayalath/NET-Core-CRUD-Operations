using NETCoreCRUDOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace NETCoreCRUDOperations.EF
{
    public class DataContext : DbContext
    {
        private readonly string connection = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=CRUDOperations;Persist Security Info=True;User ID=sa;Password=sa123";

        public virtual DbSet<Customer> tblCustomer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connection);
            }
        }
    }
}
