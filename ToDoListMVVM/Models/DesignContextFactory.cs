using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ToDoListMVVM.Models
{
    internal class DesignContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=ACARS-0099;User=sa;Password=praktyki;Database=myDb;Trust Server Certificate=True;");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}