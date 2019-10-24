using System;
using Microsoft.EntityFrameworkCore;
namespace StatisticalStorageService.Models
{
    public class LoadContext : DbContext
    {
        public DbSet<LoadData> LoadDatas { get; set; }

        public LoadContext(DbContextOptions<LoadContext> options)
            : base(options)
        {
        }    
    }
}
