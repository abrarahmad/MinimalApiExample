using Contract.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class StorageContext : DbContext 
    {
        public StorageContext(DbContextOptions<StorageContext> options)
          : base(options)
        {
        }

        public DbSet<MovieDto> Movies { get; set; }
        public DbSet<CustomerDto> Customers { get; set; }
       
    }
}
