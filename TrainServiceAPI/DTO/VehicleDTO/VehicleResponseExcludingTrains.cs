using TrainServiceAPI.Models;

namespace TrainServiceAPI.DTO.VehicleDTO
{
    public class VehicleResponseExcludingTrains
    {
        public VehicleResponseExcludingTrains(VehicleModels vehicleModels)
        {
            Id = vehicleModels.Id;
            TipoDeVeiculo = vehicleModels.TipoDeVeiculo;
            CodVeiculo = vehicleModels.CodVeiculo;
        }
        public int Id { get; set; }
        public string TipoDeVeiculo { get; set; }
        public int CodVeiculo { get; set; }
    }
}

