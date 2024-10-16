using TrainServiceAPI.DTO.VehicleDTO;

namespace TrainServiceAPI.Repositorio.Interface
{
    public interface IVehicleRepositorio
    {
        Task<VehicleResponseDTO> BuscarPorID(int id);
        Task<VehicleResponseDTO> BuscarPeloCodigo(int codVeiculo);
        Task<List<VehicleResponseDTO>> BuscarTodosOsVeiculos();        
        Task<VehicleResponseDTO> Adicionar(VehicleRequestDTO vehicleRequestDTO);
        Task<VehicleResponseDTO> Atualizar(VehicleRequestDTO vehicleRequestDTO, int id);
        Task<bool> Apagar(int id);
    }
}

