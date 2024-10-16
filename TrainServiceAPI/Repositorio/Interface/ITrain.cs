// Define os métodos; Vai conter os contratos de trem 

using TrainServiceAPI.DTO.TrainDTO;
using TrainServiceAPI.Models;

namespace TrainServiceAPI.Repositorio.Interface
{
    public interface ITrain
    {
        Task<List<TrainResponseDTO>> BuscarTodosOsTrens();
        Task<TrainResponseDTO> BuscarPorID(int id);
        Task<TrainResponseDTO> Adicionar(TrainRequestDTO trainRequestDTO);
        Task<TrainResponseDTO> Atualizar(TrainRequestDTO trainRequestDTO, int id);
        Task<bool> Apagar(int id);
    }
}

