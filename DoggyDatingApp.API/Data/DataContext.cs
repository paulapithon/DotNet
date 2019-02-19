using DoggyDatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DoggyDatingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {  }

        //Pluralize the name of the entity
        public DbSet<Value> Values { get; set; }
    }
}