using Microsoft.AspNetCore.Mvc;
using TrainServiceAPI.DTO.TrainDTO;
using TrainServiceAPI.Repositorio.Interface;

namespace TrainServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrain _trainRepositorio;

        public TrainController(ITrain trainRepositorio)
        {
            _trainRepositorio = trainRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrainResponseDTO>>> BuscarTrem()
        {
            List<TrainResponseDTO> trainResponseList = await _trainRepositorio.BuscarTodosOsTrens();
            return Ok(trainResponseList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainResponseDTO>> BuscarPorId(int id)
        {
            TrainResponseDTO trainResponseDTO = await _trainRepositorio.BuscarPorID(id);
            return Ok(trainResponseDTO);
        }

        [HttpPost]
        public async Task<ActionResult<TrainResponseDTO>> Cadastrar([FromBody] TrainRequestDTO trainRequestDTO)
        {
            TrainResponseDTO trainResponseDTO = await _trainRepositorio.Adicionar(trainRequestDTO);
            return Ok(trainResponseDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TrainResponseDTO>> Atualizar([FromBody] TrainRequestDTO trainRequestDTO, int id)
        {
            TrainResponseDTO trainResponseDTO = await _trainRepositorio.Atualizar(trainRequestDTO, id);
            return Ok(trainResponseDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar([FromRoute] int id)
        {
            bool apagado = await _trainRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
