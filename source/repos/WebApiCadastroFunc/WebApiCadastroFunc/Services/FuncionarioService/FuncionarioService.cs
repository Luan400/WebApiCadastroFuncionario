using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using WebApiCadastroFunc.DataContest;
using WebApiCadastroFunc.Models;

namespace WebApiCadastroFunc.Services.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<FuncionariosModel>>> CreateFuncionario(FuncionariosModel novoFuncionario)
        {
            ServiceResponse<List<FuncionariosModel>> serviceResponse = new ServiceResponse<List<FuncionariosModel>>();

            try
            {
                if (novoFuncionario == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Informar dados!";
                return serviceResponse;
                }
                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();
                  
                serviceResponse.Dados= _context.Funcionarios.ToList();
            }
            catch (Exception ex) {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionariosModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionariosModel>> serviceResponse = new ServiceResponse<List<FuncionariosModel>>();

            try
            {
                FuncionariosModel funcionario = _context.Funcionarios.FirstOrDefault(p => p.Id == id);
                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Usuário não localiizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Funcionarios.Remove(funcionario);

                await _context.SaveChangesAsync();

                serviceResponse.Dados=_context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<FuncionariosModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionariosModel> serviceResponse = new ServiceResponse<FuncionariosModel>();

            try
            {
                FuncionariosModel funcionario = _context.Funcionarios.FirstOrDefault(p => p.Id == id);
                if(funcionario == null)
                {
                    serviceResponse.Message = "Usuário não localiizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = funcionario;

            }catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionariosModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionariosModel>> serviceResponse = new ServiceResponse<List<FuncionariosModel>>();

            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();

                if (serviceResponse.Dados.Count == 0) {

                     serviceResponse.Message = "Nenhuma mensagem foi encontrada";

                }
            }
            catch (Exception ex )
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<FuncionariosModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionariosModel>> serviceResponse = new ServiceResponse<List<FuncionariosModel>>();

            try
            {
                FuncionariosModel funcionariosModel = _context.Funcionarios.FirstOrDefault(P => P.Id == id);

                if (funcionariosModel == null)
                {
                    serviceResponse.Message = "Usuário não localiizado!";
                    serviceResponse.Sucesso = false;
                }

                funcionariosModel.Ativo=false;
                funcionariosModel.DataDeAlteracao = DateTime.Now.ToLocalTime();
               
                _context.Funcionarios.Update(funcionariosModel);

                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();


            }
            catch (Exception ex) {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionariosModel>>> UpdateFuncionarios(FuncionariosModel editadoFuncionario)
        {
            ServiceResponse<List<FuncionariosModel>> serviceResponse = new ServiceResponse<List<FuncionariosModel>>();

            try
            {
                FuncionariosModel funcionariosModel = _context.Funcionarios.FirstOrDefault(P => P.Id == editadoFuncionario.Id);

                if (funcionariosModel == null) {
                    serviceResponse.Message = "Usuário não localiizado!";
                    serviceResponse.Sucesso = false;
                }

                funcionariosModel.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucesso = false;

            }
            return serviceResponse;
           
        }
    }
}
