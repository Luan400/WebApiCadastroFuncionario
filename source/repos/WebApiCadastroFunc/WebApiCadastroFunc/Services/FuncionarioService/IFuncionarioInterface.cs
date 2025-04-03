using WebApiCadastroFunc.Models;

namespace WebApiCadastroFunc.Services.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionariosModel>>> GetFuncionarios();
        Task<ServiceResponse<List<FuncionariosModel>>> CreateFuncionario(FuncionariosModel novoFuncionario);

        Task<ServiceResponse<FuncionariosModel>> GetFuncionarioById(int id);

        Task<ServiceResponse<List<FuncionariosModel>>> UpdateFuncionarios(FuncionariosModel editadoFuncionario);

        Task<ServiceResponse<List<FuncionariosModel>>> DeleteFuncionario(int id);

        Task<ServiceResponse<List<FuncionariosModel>>> InativaFuncionario(int id);
    }
}
