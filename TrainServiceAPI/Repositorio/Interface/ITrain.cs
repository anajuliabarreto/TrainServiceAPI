// Define os métodos; Vai conter os contratos de trem 

using TrainServiceAPI.DTO.TrainDTO;

namespace TrainServiceAPI.Repositorio.Interface
{
    public interface ITrain
    {
        Task<List<TrainResponseDTO>> BuscarTodosOsTrens();
        Task<TrainResponseDTO> BuscarPorID(int id);
        Task<TrainResponseDTO> Adicionar(TrainRequestDTO trainRequestDTO, string nomeUsuario);
        Task<TrainResponseDTO> Atualizar(TrainRequestDTO trainRequestDTO, int id, string nomeUsuario);
        Task<bool> Apagar(int id);
    }
}

