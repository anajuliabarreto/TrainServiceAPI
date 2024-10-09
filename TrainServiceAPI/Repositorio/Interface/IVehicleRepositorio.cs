using TrainServiceAPI.Models;

namespace TrainServiceAPI.Repositorio.Interface
{
    public interface IVehicleRepositorio
    {
        Task<List<VehicleModels>> BuscarTodosOsVeiculos();
        Task<VehicleModels> BuscarPorID(int id);
        Task<VehicleModels> Adicionar(VehicleModels train);
        Task<VehicleModels> Atualizar(VehicleModels train, int id);
        Task<bool> Apagar(int id);
    }
}

