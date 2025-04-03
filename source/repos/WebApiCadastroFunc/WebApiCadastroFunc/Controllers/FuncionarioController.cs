using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCadastroFunc.Models;
using WebApiCadastroFunc.Services.FuncionarioService;

namespace WebApiCadastroFunc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }
        [HttpGet]

        public async Task<ActionResult<ServiceResponse<List<FuncionariosModel>>>> GetFuncionarios() {

            return Ok(await _funcionarioInterface.GetFuncionarios());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ServiceResponse<FuncionariosModel>>> GetFuncionarioById(int id)
        {
           ServiceResponse<FuncionariosModel> serviceResponse = await _funcionarioInterface.GetFuncionarioById(id);
            
            return Ok(serviceResponse);
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<FuncionariosModel>>>> CreateFuncionario(FuncionariosModel novoFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionariosModel>>>> UpdateFuncionarios(FuncionariosModel editadoFuncionario)
        {
            ServiceResponse<List<FuncionariosModel>> serviceResponse = await _funcionarioInterface.UpdateFuncionarios(editadoFuncionario);

            return Ok(serviceResponse);
        }


        [HttpPut("InativaFuncionario")]

        public async Task<ActionResult<ServiceResponse<FuncionariosModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionariosModel>> serviceResponse = await _funcionarioInterface.InativaFuncionario(id);

            return Ok(serviceResponse);
        }

        [HttpDelete]

        public async Task<ActionResult<ServiceResponse<List<FuncionariosModel>>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionariosModel>> serviceResponse = await _funcionarioInterface.DeleteFuncionario(id);

            return Ok(serviceResponse);
        }
    }
}
