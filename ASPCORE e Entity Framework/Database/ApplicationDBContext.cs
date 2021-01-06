using Microsoft.EntityFrameworkCore;
using ASPCORE.Models;

namespace ASPCORE.Database 
{
    public class ApplicationDBContext : DbContext
    {

        public DbSet<Funcionario> Funcionarios { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base (options) {}
    }
}