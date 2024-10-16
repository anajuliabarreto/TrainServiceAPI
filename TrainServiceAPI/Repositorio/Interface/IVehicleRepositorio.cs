using TrainServiceAPI.DTO.VehicleDTO;
using TrainServiceAPI.Models;

namespace TrainServiceAPI.Repositorio.Interface
{
    public interface IVehicleRepositorio
    {
        Task<VehicleResponseDTO> BuscarPorID(int id);
        Task<VehicleResponseDTO> BuscarPeloCodigo(int codVeiculo);
        Task<List<VehicleResponseDTO>> BuscarTodosOsVeiculos();        
        Task<VehicleResponseDTO> Adicionar(VehicleResponseDTO vehicleResponseDTO);
        Task<VehicleResponseDTO> Atualizar(VehicleResponseDTO vehicleResponseDTO, int id);
        Task<bool> Apagar(int id);
    }
}

