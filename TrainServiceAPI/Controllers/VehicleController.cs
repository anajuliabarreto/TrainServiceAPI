using Microsoft.AspNetCore.Mvc;
using TrainServiceAPI.Models;
using TrainServiceAPI.Repositorio.Interface;

namespace TrainServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepositorio _vehicleRepositorio;

        public VehicleController(IVehicleRepositorio vehicleRepositorio)
        {
            _vehicleRepositorio = vehicleRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleModels>>> ListarTodos()
        {
            List<VehicleModels> vehicle = await _vehicleRepositorio.BuscarTodosOsVeiculos();
            return Ok(vehicle);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModels>> BuscarPorId(int id)
        {
            VehicleModels vehicle = await _vehicleRepositorio.BuscarPorID(id);
            return Ok(vehicle);
        }


        [HttpPost]
        public async Task<ActionResult<VehicleModels>> Cadastrar([FromBody] VehicleModels vehicleModels)
        {
            VehicleModels vehicle = await _vehicleRepositorio.Adicionar(vehicleModels);
            return Ok(vehicle);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleModels>> Atualizar([FromBody] VehicleModels vehicleModels, int id)
        {
            vehicleModels.Id = id;
            VehicleModels vehicle = await _vehicleRepositorio.Atualizar(vehicleModels, id);
            return Ok(vehicle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleModels>> Deletar(int id)
        {
            bool apagado = await _vehicleRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
