using Api_Up_Base.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Up_Base.Database {
    public class ApiUpBaseContext : DbContext {

        public ApiUpBaseContext(DbContextOptions<ApiUpBaseContext> opt) : base(opt) { }

        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
