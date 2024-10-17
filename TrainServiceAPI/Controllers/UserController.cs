using Microsoft.AspNetCore.Mvc;
using TrainServiceAPI.DTO.TrainDTO;
using TrainServiceAPI.DTO.UserDTO;
using TrainServiceAPI.Repositorio;
using TrainServiceAPI.Repositorio.Interface;

namespace TrainServiceAPI.Controllers
{
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
        public async Task<ActionResult<UserResponseDTO>> BuscarPorId(int id)
        {
            UserResponseDTO userResponseDTO = await _userRepositorio.BuscarPorID(id);
            return Ok(userResponseDTO);
        }

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
