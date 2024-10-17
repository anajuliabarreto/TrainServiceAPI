//Vai implementar a interface, oferencendo a lógica do que foi definido na interface 
using Microsoft.EntityFrameworkCore;
using TrainServiceAPI.Data;
using TrainServiceAPI.DTO.TrainDTO;
using TrainServiceAPI.Models;
using TrainServiceAPI.Repositorio.Interface;

namespace TrainServiceAPI.Repositorio
{
    public class TrainRepositorio : ITrain
    {
        private readonly TrainServiceDBContext _dbContext;

        public TrainRepositorio(TrainServiceDBContext trainServiceDBContext)
        {
            _dbContext = trainServiceDBContext;
        }

        public async Task<TrainResponseDTO> BuscarPorID(int id)
        {
            TrainModels trainModels = await _dbContext.Trens
                .Include((x) => x.Veiculos)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (trainModels == null) throw new Exception($"Trem referente ao ID: {id} não foi encontrado");
            return new TrainResponseDTO(trainModels);
        }

        public async Task<List<TrainResponseDTO>> BuscarTodosOsTrens()
        {
            List<TrainModels> trainModelsList = await _dbContext.Trens
                .Include((x) => x.Veiculos)
                .ToListAsync();
            return trainModelsList.Select((trainModels) => new TrainResponseDTO(trainModels)).ToList();
        }

        public async Task<TrainResponseDTO> Adicionar(TrainRequestDTO trainRequestDTO)
        {
            TrainModels trainModels = new TrainModels
            {
                LocalDeOrigem = trainRequestDTO.LocalDeOrigem,
                LocalDeDestino = trainRequestDTO.LocalDeDestino,
                NumeroTrem = trainRequestDTO.NumeroTrem,
                Ferrovia = trainRequestDTO.Ferrovia,
                DataHoraPartida = trainRequestDTO.DataHoraPartida
            };
           
            if (trainRequestDTO.CodVeiculos != null && trainRequestDTO.CodVeiculos.Count > 0)
            {
                List<VehicleModels> vehicleModelsList = new List<VehicleModels>();

                foreach (int codVeiculo in trainRequestDTO.CodVeiculos)
                {
                    VehicleModels vehicleModels = await _dbContext.Veiculos.FirstOrDefaultAsync((x) => x.CodVeiculo == codVeiculo);
                    if (vehicleModels != null)
                        vehicleModelsList.Add(vehicleModels);
                }

                if (vehicleModelsList.Count > 0)
                    trainModels.Veiculos = vehicleModelsList;
            }

            await _dbContext.Trens.AddAsync(trainModels);
            await _dbContext.SaveChangesAsync();

            return new TrainResponseDTO(trainModels);
        }

        public async Task<TrainResponseDTO> Atualizar(TrainRequestDTO trainRequestDTO, int id)
        {
            TrainModels trainModels = await _dbContext.Trens
                .Include((x) => x.Veiculos)
                .FirstOrDefaultAsync((x) => x.Id == id);

            if (trainModels == null)
            {
                throw new Exception($"Trem referente ao ID: {id} não foi encontrado");
            }

            trainModels.LocalDeOrigem = trainRequestDTO.LocalDeOrigem;
            trainModels.LocalDeDestino = trainRequestDTO.LocalDeDestino;
            trainModels.NumeroTrem = trainRequestDTO.NumeroTrem;
            trainModels.Ferrovia = trainRequestDTO.Ferrovia;
            trainModels.DataHoraPartida = trainRequestDTO.DataHoraPartida;

            
            if (trainRequestDTO.CodVeiculos != null && trainRequestDTO.CodVeiculos.Count > 0)
            {
                List<VehicleModels> vehicleModelsList = new List<VehicleModels>();

                foreach (int codVeiculo in trainRequestDTO.CodVeiculos)
                {
                    VehicleModels vehicleModels = await _dbContext.Veiculos.FirstOrDefaultAsync((x) => x.CodVeiculo == codVeiculo);
                    if (vehicleModels != null)
                        vehicleModelsList.Add(vehicleModels);
                }

                if (vehicleModelsList.Count > 0)
                    trainModels.Veiculos = vehicleModelsList;
            }
            
            _dbContext.Trens.Update(trainModels);
            await _dbContext.SaveChangesAsync();

            return new TrainResponseDTO(trainModels);
        }

        public async Task<bool> Apagar(int id)
        {
            TrainModels trainModels = await _dbContext.Trens
                .Include((x) => x.Veiculos)
                .FirstOrDefaultAsync((x) => x.Id == id);
          
            if (trainModels == null)
            {
                throw new Exception($"Trem referente ao ID: {id} não foi encontrado");
            }

            _dbContext.Trens.Remove(trainModels);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
