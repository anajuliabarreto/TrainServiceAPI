using TrainServiceAPI.Models;

namespace TrainServiceAPI.DTO.UserDTO
{
    public class UserResponseDTO
    {
        public UserResponseDTO(UserModels userModels)
        {
            Id = userModels.Id;
            NomeUsuario = userModels.NomeUsuario;
            SenhaUsuario = "******";
        }
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string SenhaUsuario { get; set; }
    }
}
