// Vai conter os contratos de trem 

using TrainServiceAPI.Models;

namespace TrainServiceAPI.Repositorio.Interface
{
    public interface ITrain
    {
        Task<List<TrainModels>> BuscarTodosOsTrens();
        Task<TrainModels> BuscarPorID(int id);
        Task<TrainModels> Adicionar(TrainModels train);
        Task<TrainModels> Atualizar(TrainModels train, int id);
        Task<bool> Apagar(int id);
    }
}

