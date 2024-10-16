﻿//Vai implementar a interface, oferencendo a lógica do que foi definido na interface 
using Microsoft.EntityFrameworkCore;
using TrainServiceAPI.Data;
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

        public async Task<TrainModels> BuscarPorID(int id)
        {
            return await _dbContext.Trens
                .Include((x) => x.Veiculos)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TrainModels>> BuscarTodosOsTrens()
        {
            return await _dbContext.Trens.Include((x) => x.Veiculos).ToListAsync();
        }

        public async Task<TrainModels> Adicionar(TrainModels train)
        {
            List<VehicleModels> vehicleModelsList = new List<VehicleModels>();
            if (train.Veiculos != null && train.Veiculos.Count > 0)
            {
                foreach (VehicleModels vehicle in train.Veiculos)
                {

                    VehicleModels vehicleModels = await _dbContext.Veiculos.FirstOrDefaultAsync((x) => x.Id == vehicle.Id);
                    if (vehicleModels != null)
                        vehicleModelsList.Add(vehicleModels);
                }

            }
            if (vehicleModelsList.Count > 0)
                train.Veiculos = vehicleModelsList;

            await _dbContext.Trens.AddAsync(train);
            await _dbContext.SaveChangesAsync();

            return train;
        }


        public async Task<TrainModels> Atualizar(TrainModels train, int id)
        {
            TrainModels tremPorID = await BuscarPorID(id);

            if (tremPorID == null)
            {
                throw new Exception($"Trem referente ao ID: {id} não foi encontrado");
            }

            List<VehicleModels> vehicleModelsList = new List<VehicleModels>();
            if (train.Veiculos != null && train.Veiculos.Count > 0)
            {
                foreach (VehicleModels vehicle in train.Veiculos)
                {

                    VehicleModels vehicleModels = await _dbContext.Veiculos.FirstOrDefaultAsync((x) => x.Id == vehicle.Id);
                    if (vehicleModels != null)
                        vehicleModelsList.Add(vehicleModels);
                }

            }
            if (vehicleModelsList.Count > 0)
                tremPorID.Veiculos = vehicleModelsList;

            tremPorID.LocalDeOrigem = train.LocalDeOrigem;
            tremPorID.LocalDeDestino = train.LocalDeDestino;
            tremPorID.Ferrovia = train.Ferrovia;
            tremPorID.DataHoraPartida = train.DataHoraPartida;

            _dbContext.Trens.Update(tremPorID);
            await _dbContext.SaveChangesAsync();

            return tremPorID;
        }


        public async Task<bool> Apagar(int id)
        {
            TrainModels tremPorID = await BuscarPorID(id);

            if (tremPorID == null)
            {
                throw new Exception($"Trem referente ao ID: {id} não foi encontrado");
            }

            _dbContext.Trens.Remove(tremPorID);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
