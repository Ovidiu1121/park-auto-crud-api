using Microsoft.EntityFrameworkCore;
using ParkAutoCrudApi.Cars.Model;

namespace ParkAutoCrudApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Car> Cars { get; set; }
    }
}
