using Microsoft.EntityFrameworkCore;
using TrainServiceAPI.Data;
using TrainServiceAPI.DTO.UserDTO;
using TrainServiceAPI.Models;
using TrainServiceAPI.Repositorio.Interface;
using TrainServiceAPI.Services;

namespace TrainServiceAPI.Repositorio
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly TrainServiceDBContext _dbContext;
        public UserRepositorio(TrainServiceDBContext trainServiceDBContext)
        {
            _dbContext = trainServiceDBContext;
        }
        public async Task<UserResponseDTO> BuscarPorID(int id)
        {
            UserModels userModels = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (userModels == null) throw new Exception($"Usuário referente ao ID: {id} não foi encontrado");
            return new UserResponseDTO(userModels);
        }

        public async Task<List<UserResponseDTO>> BuscarTodosUsuarios()
        {
            List<UserModels> userModelsList = await _dbContext.Usuarios.ToListAsync();
            return userModelsList.Select((userModels) => new UserResponseDTO(userModels)).ToList();
        }

        public async Task<UserResponseDTO> BuscarPeloNome(string nomeUsuario)
        {
            UserModels userModels = await _dbContext.Usuarios.FirstOrDefaultAsync((x) => x.NomeUsuario == nomeUsuario);
            if (userModels == null) throw new Exception($"O usuário: {nomeUsuario} não foi encontrado no banco de dados.");
            return new UserResponseDTO(userModels);
        }

        public async Task<UserAccessResponseDTO> Adicionar(UserRequestDTO userRequestDTO)
        {
            UserModels userModels = new UserModels
            {
                NomeUsuario = userRequestDTO.NomeUsuario,
                SenhaUsuario = userRequestDTO.SenhaUsuario,
            };            

            await _dbContext.Usuarios.AddAsync(userModels);
            await _dbContext.SaveChangesAsync();

            string token = TokenService.GenerateToken(userModels);

            return new UserAccessResponseDTO(userModels, token);
        }
        public async Task<UserResponseDTO> Atualizar(UserRequestDTO userRequestDTO, int id) 
        {         
            UserModels userModels = await _dbContext.Usuarios.FirstOrDefaultAsync((x) => x.Id == id);
            if (userModels == null) throw new Exception($"Usuário referente ao ID: {id} não foi encontrado");

            userModels.NomeUsuario = userRequestDTO.NomeUsuario;
            userModels.SenhaUsuario = userRequestDTO.SenhaUsuario;

            _dbContext.Usuarios.Update(userModels);
            await _dbContext.SaveChangesAsync();

            return new UserResponseDTO(userModels);
        }
        public async Task<bool> Apagar(int id)
        {
            UserModels userModels = await _dbContext.Usuarios.FirstOrDefaultAsync((x) => x.Id == id);

            if (userModels == null)
            {
                throw new Exception($"Usuário referente ao ID: {id} não foi encontrado");
            }

            _dbContext.Usuarios.Remove(userModels);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
