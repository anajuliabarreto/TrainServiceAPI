using TrainServiceAPI.Models;

namespace TrainServiceAPI.DTO.UserDTO
{
    public class UserAccessResponseDTO : UserResponseDTO 
    { 
        
        public UserAccessResponseDTO (UserModels userModels) : base (userModels) 
        {
            Id = userModels.Id;
            NomeUsuario = userModels.NomeUsuario;
            SenhaUsuario = userModels.SenhaUsuario;
        }      
    }
}
