using TrainServiceAPI.DTO.UserDTO;

namespace TrainServiceAPI.Repositorio.Interface
{
    public interface IUserRepositorio
    {        
        Task<UserResponseDTO> BuscarPorID(int id);
        Task<List<UserResponseDTO>> BuscarTodosUsuarios();
        Task<UserAccessResponseDTO> BuscarPeloNome(string nomeUsuario);
        Task<UserAccessResponseDTO> Adicionar(UserRequestDTO userRequestDTO);
        Task<UserResponseDTO> Atualizar(UserRequestDTO userRequestDTO, int id);
        Task<bool> Apagar(int id);
    }
}
    