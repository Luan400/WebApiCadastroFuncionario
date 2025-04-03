using Microsoft.EntityFrameworkCore;
using WebApiCadastroFunc.Models;

namespace WebApiCadastroFunc.DataContest
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<FuncionariosModel> Funcionarios { get; set; }
    }
}
