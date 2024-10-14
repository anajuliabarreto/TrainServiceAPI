using Microsoft.AspNetCore.Mvc;
using TrainServiceAPI.Models;
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
        public async Task<ActionResult<List<TrainModels>>> BuscarTrem()
        {
            List<TrainModels> trens = await _trainRepositorio.BuscarTodosOsTrens();
            return Ok(trens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainModels>> BuscarPorId(int id)
        {
            TrainModels trens = await _trainRepositorio.BuscarPorID(id);
            return Ok(trens);
        }


        [HttpPost]
        public async Task<ActionResult<TrainModels>> Cadastrar([FromBody] TrainModels trainModels)
        {
            TrainModels trens = await _trainRepositorio.Adicionar(trainModels);
            return Ok(trens);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TrainModels>> Atualizar([FromBody] TrainModels trainModels, int id)
        {
            trainModels.Id = id;
            TrainModels trens = await _trainRepositorio.Atualizar(trainModels, id);
            return Ok(trens);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TrainModels>> Deletar(int id)
        {
            bool apagado = await _trainRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
