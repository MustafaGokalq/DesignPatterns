using Microsoft.EntityFrameworkCore;

namespace DesignPattern.ChainOfResposibility.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=monster;initial catalog=DesignPattern1;integrated security=true;");
        }

        public DbSet<CustomerProcess> CustomerProcess { get; set; }
    }
}