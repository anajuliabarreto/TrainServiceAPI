using Microsoft.EntityFrameworkCore;
using TrainServiceAPI.Data;
using TrainServiceAPI.DTO.TrainDTO;
using TrainServiceAPI.DTO.VehicleDTO;
using TrainServiceAPI.Models;
using TrainServiceAPI.Repositorio.Interface;

namespace TrainServiceAPI.Repositorio
{
    public class VehicleRepositorio: IVehicleRepositorio
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

        public async Task<VehicleModels> Adicionar(VehicleModels vehicle)
        {
            List<TrainModels> trainModelsList = new List<TrainModels>();
            if (vehicle.Trens != null && vehicle.Trens.Count > 0)
            {
                foreach (TrainModels train in vehicle.Trens)
                {

                    TrainModels trainModels = await _dbContext.Trens.FirstOrDefaultAsync((x) => x.Id == train.Id);
                    if (trainModels != null)
                        trainModelsList.Add(trainModels);
                }

            }
            if (trainModelsList.Count > 0)
                vehicle.Trens = trainModelsList;

            await _dbContext.Veiculos.AddAsync(vehicle);
            await _dbContext.SaveChangesAsync();

            return vehicle;
        }

        public async Task<VehicleModels> Atualizar(VehicleModels vehicle, int id)
        {
            VehicleModels veiculoPorID = await BuscarPorID(id);

            if (veiculoPorID == null)
            {
                throw new Exception($"Veículo referente ao ID: {id} não foi encontrado");
            }

            List<TrainModels> trainModelsList = new List<TrainModels>();
            if (vehicle.Trens != null && vehicle.Trens.Count > 0)
            {
                foreach (TrainModels train in vehicle.Trens)
                {
                    TrainModels trainModels = await _dbContext.Trens.FirstOrDefaultAsync((x) => x.Id == train.Id);
                    if (trainModels != null)
                        trainModelsList.Add(trainModels);
                }
            }
            if (trainModelsList.Count > 0)
                veiculoPorID.Trens = trainModelsList;

            veiculoPorID.TipoDeVeiculo = vehicle.TipoDeVeiculo;
            veiculoPorID.CodVeiculo = vehicle.CodVeiculo;
            //veiculoPorID.Status = vehicle.Status;

            _dbContext.Veiculos.Update(veiculoPorID);
            await _dbContext.SaveChangesAsync();

            return veiculoPorID;
        }

        public async Task<bool> Apagar(int id)
        {
            VehicleModels veiculoPorID = await BuscarPorID(id);

            if (veiculoPorID == null)
            {
                throw new Exception($"Veículo referente ao ID: {id} não foi encontrado");
            }

            _dbContext.Veiculos.Remove(veiculoPorID);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
