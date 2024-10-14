using Microsoft.EntityFrameworkCore;
using TrainServiceAPI.Data;
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

        public async Task<VehicleModels> BuscarPorID(int id)
        {
            return await _dbContext.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<VehicleModels>> BuscarTodosOsVeiculos()
        {
            return await _dbContext.Veiculos. ToListAsync();
        }

        public async Task<VehicleModels> Adicionar(VehicleModels vehicle)
        {
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
