using TrainServiceAPI.Models;

namespace TrainServiceAPI.DTO.UserDTO
{
    public class UserAccessResponseDTO : UserResponseDTO 
    {         
        public UserAccessResponseDTO(UserModels userModels, string token = "") : base(userModels)
        {
            Id = userModels.Id;
            NomeUsuario = userModels.NomeUsuario;
            SenhaUsuario = userModels.SenhaUsuario;
            Token = token;
        }
        public string? Token { get; set; }
    }
}
