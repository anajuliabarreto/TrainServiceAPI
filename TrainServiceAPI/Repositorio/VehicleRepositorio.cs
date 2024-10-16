using Microsoft.EntityFrameworkCore;
using TrainServiceAPI.Data;
using TrainServiceAPI.DTO.VehicleDTO;
using TrainServiceAPI.Models;
using TrainServiceAPI.Repositorio.Interface;

namespace TrainServiceAPI.Repositorio
{
    public class VehicleRepositorio :  IVehicleRepositorio
    {
        private readonly TrainServiceDBContext _dbContext;
        public VehicleRepositorio(TrainServiceDBContext trainServiceDBContext)
        {
            _dbContext = trainServiceDBContext;
        }

        public async Task<VehicleResponseDTO> BuscarPorID(int id)
        {
            VehicleModels vehicleModels = await _dbContext.Veiculos
                .Include((x) => x.Trens)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (vehicleModels == null) throw new Exception($"Veículo referente ao ID: {id} não foi encontrado");
            return new VehicleResponseDTO(vehicleModels);
        }

        public async Task<VehicleResponseDTO> BuscarPeloCodigo(int codVeiculo)
        {
            VehicleModels vehicleModels = await _dbContext.Veiculos
                .Include((x) => x.Trens)
                .FirstOrDefaultAsync(x => x.CodVeiculo == codVeiculo);
            if (vehicleModels == null) throw new Exception($"Veículo referente ao código: {codVeiculo} não foi encontrado");
            return new VehicleResponseDTO(vehicleModels);
        }
        
        public async Task<List<VehicleResponseDTO>> BuscarTodosOsVeiculos()
        {
            List<VehicleModels> vehicleModelsList = await _dbContext.Veiculos
                .Include((x) => x.Trens)
                .ToListAsync();
            return vehicleModelsList.Select((vehicleModels) => new VehicleResponseDTO(vehicleModels)).ToList();
        }

        public async Task<VehicleResponseDTO> Adicionar(VehicleRequestDTO vehicleRequestDTO)
        {
            List<TrainModels> trainModelsList = new List<TrainModels>();

            if (vehicleRequestDTO.TrensId != null && vehicleRequestDTO.TrensId.Count > 0)
            {
                foreach (int tremId in vehicleRequestDTO.TrensId)
                {
                    TrainModels trainModels = await _dbContext.Trens.FirstOrDefaultAsync((x) => x.Id == tremId);
                    if (trainModels != null)
                        trainModelsList.Add(trainModels);
                }
            }

            VehicleModels vehicleModels = new VehicleModels
            {
                CodVeiculo = vehicleRequestDTO.CodVeiculo,
                TipoDeVeiculo = vehicleRequestDTO.TipoDeVeiculo,
                Trens = trainModelsList                
            };

            await _dbContext.Veiculos.AddAsync(vehicleModels);
            await _dbContext.SaveChangesAsync();

            return new VehicleResponseDTO(vehicleModels);
        }

        public async Task<VehicleResponseDTO> Atualizar(VehicleRequestDTO vehicleRequestDTO, int id)
        {

            VehicleModels vehicleModels = await _dbContext.Veiculos
                .Include((x) => x.Trens)
                .FirstOrDefaultAsync((x) => x.Id == id);

            if (vehicleModels == null)
            {
                throw new Exception($"Veículo referente ao ID: {id} não foi encontrado");
            }

            List<TrainModels> trainModelsList = new List<TrainModels>();

            if (vehicleRequestDTO.TrensId != null && vehicleRequestDTO.TrensId.Count > 0)
            {
                foreach (int tremId in vehicleRequestDTO.TrensId)
                {
                    TrainModels trainModels = await _dbContext.Trens.FirstOrDefaultAsync((x) => x.Id == tremId);
                    if (trainModels != null)
                        trainModelsList.Add(trainModels);
                }
            }

            vehicleModels.TipoDeVeiculo = vehicleRequestDTO.TipoDeVeiculo;
            vehicleModels.CodVeiculo = vehicleRequestDTO.CodVeiculo;
            vehicleModels.Trens = trainModelsList;
            //veiculoPorID.Status = vehicle.Status;

            _dbContext.Veiculos.Update(vehicleModels);
            await _dbContext.SaveChangesAsync();

            return new VehicleResponseDTO(vehicleModels);
        }

        public async Task<bool> Apagar(int id)
        {
            VehicleModels vehicleModels = await _dbContext.Veiculos
                .Include((x) => x.Trens)
                .FirstOrDefaultAsync((x) => x.Id == id);

            if (vehicleModels == null)
            {
                throw new Exception($"Veículo referente ao ID: {id} não foi encontrado");
            }

            _dbContext.Remove(vehicleModels);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
