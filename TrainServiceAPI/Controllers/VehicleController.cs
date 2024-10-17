using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainServiceAPI.DTO.VehicleDTO;
using TrainServiceAPI.Models;
using TrainServiceAPI.Repositorio.Interface;

namespace TrainServiceAPI.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<List<VehicleResponseDTO>>> ListarTodos()
        {
            List<VehicleResponseDTO> vehicleResponseList = await _vehicleRepositorio.BuscarTodosOsVeiculos();
            return Ok(vehicleResponseList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleResponseDTO>> BuscarPorId(int id)
        {
            VehicleResponseDTO vehicleResponseDTO = await _vehicleRepositorio.BuscarPorID(id);
            return Ok(vehicleResponseDTO);
        }

        [HttpGet("codVeiculo/{codVeiculo}")]
        public async Task<ActionResult<VehicleResponseDTO>> BuscarPeloCodigo([FromRoute] int codVeiculo)
        {
            VehicleResponseDTO vehicleResponseDTO = await _vehicleRepositorio.BuscarPeloCodigo(codVeiculo);
            return Ok(vehicleResponseDTO);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleResponseDTO>> Cadastrar([FromBody] VehicleRequestDTO vehicleRequestDTO)
        {
            VehicleResponseDTO vehicleResponseDTO = await _vehicleRepositorio.Adicionar(vehicleRequestDTO);
            return Ok(vehicleResponseDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleModels>> Atualizar([FromBody] VehicleRequestDTO vehicleRequestDTO, int id)
        {
            VehicleResponseDTO vehicleResponseDTO = await _vehicleRepositorio.Atualizar(vehicleRequestDTO, id);
            return Ok(vehicleResponseDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            bool apagado = await _vehicleRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
