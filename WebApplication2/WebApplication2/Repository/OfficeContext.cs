using System.Data.Entity;
using WebApplication2.Models;

namespace WebApplication2.Repository {
    public class OfficeContext: DbContext {
        public OfficeContext(string connString) : base(connString) { }
        public DbSet<Worker> Workers { get; set; }
    }
}
