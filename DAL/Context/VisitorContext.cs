using Microsoft.EntityFrameworkCore;
using TraversalApiProect.DAL.Entities;

namespace TraversalApiProect.DAL.Context
{
    public class VisitorContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-IDVTKKC\\SQLEXPRESS;initial catalog=TraversalDbApi;integrated security=true");
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
