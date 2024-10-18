using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainServiceAPI.DTO.UserDTO;
using TrainServiceAPI.Models;
using TrainServiceAPI.Repositorio.Interface;
using TrainServiceAPI.Services;

namespace TrainServiceAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly IUserRepositorio _userRepositorio;

        public UserController(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponseDTO>>> BuscarUsuarios()
        {
            List<UserResponseDTO> userResponseList = await _userRepositorio.BuscarTodosUsuarios();
            return Ok(userResponseList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTO>> BuscarPorId([FromRoute]int id)
        {
            UserResponseDTO userResponseDTO = await _userRepositorio.BuscarPorID(id);
            return Ok(userResponseDTO);
        }

        [AllowAnonymous]
        [HttpGet("token")]
        public async Task<ActionResult<object>> GetToken([FromQuery] string nomeUsuario, [FromQuery] string senhaUsuario)
        {            
            UserAccessResponseDTO userResponseDTO = await _userRepositorio.BuscarPeloNome(nomeUsuario);

            if (userResponseDTO == null)
                throw new Exception($"Usuário não encontrado");

            if (userResponseDTO.SenhaUsuario != senhaUsuario)
                throw new Exception("Nome de usuário ou senha incorretos");
            UserModels userModels = new UserModels
            {
                Id = userResponseDTO.Id,
                NomeUsuario = userResponseDTO.NomeUsuario,
                SenhaUsuario = userResponseDTO.SenhaUsuario
            };
            return Ok(TokenService.GenerateToken(userModels));            
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> Cadastrar([FromBody] UserRequestDTO userRequestDTO)
        {
            UserResponseDTO userResponseDTO = await _userRepositorio.Adicionar(userRequestDTO);
            return Ok(userResponseDTO);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponseDTO>> Atualizar([FromBody] UserRequestDTO userRequestDTO, int id)
        {
            UserResponseDTO userResponseDTO = await _userRepositorio.Atualizar(userRequestDTO, id);
            return Ok(userResponseDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar([FromRoute] int id)
        {
            bool apagado = await _userRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
