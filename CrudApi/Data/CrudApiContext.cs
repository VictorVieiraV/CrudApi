using Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Data {
    public class CrudApiContext : DbContext {
        public CrudApiContext(DbContextOptions<CrudApiContext> options)
            : base(options) {
        }

        public DbSet<Colaborador> Colaborador { get; set; }
    }
}
