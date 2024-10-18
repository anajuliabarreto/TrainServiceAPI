using TrainServiceAPI.Models;

namespace TrainServiceAPI.DTO.UserDTO
{
    public class UserAccessResponseDTO : UserResponseDTO 
    {         
        public UserAccessResponseDTO(UserModels userModels, string? tokenParam = null) : base(userModels)
        {
            Id = userModels.Id;
            NomeUsuario = userModels.NomeUsuario;
            SenhaUsuario = userModels.SenhaUsuario;
            Token = tokenParam ?? "";
        }
        public string? Token { get; set; }
    }
}
