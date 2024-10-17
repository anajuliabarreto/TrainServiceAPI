using TrainServiceAPI.DTO.VehicleDTO;

namespace TrainServiceAPI.Repositorio.Interface
{
    public interface IVehicleRepositorio
    {
        Task<VehicleResponseDTO> BuscarPorID(int id);
        Task<VehicleResponseDTO> BuscarPeloCodigo(int codVeiculo);
        Task<List<VehicleResponseDTO>> BuscarTodosOsVeiculos();        
        Task<VehicleResponseDTO> Adicionar(VehicleRequestDTO vehicleRequestDTO, string nomeUsuario);
        Task<VehicleResponseDTO> Atualizar(VehicleRequestDTO vehicleRequestDTO, int id, string nomeUsuario);
        Task<bool> Apagar(int id);
    }
}

