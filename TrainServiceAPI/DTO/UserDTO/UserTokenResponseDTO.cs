using TrainServiceAPI.Models;

namespace TrainServiceAPI.DTO.UserDTO
{
    public class UserTokenResponseDTO : UserResponseDTO
    {
        public UserTokenResponseDTO (UserModels userModels, string token) : base(userModels) {
            Id = userModels.Id;
            Token = token;
        }
        public string? Token { get; set; }
    }

}
