using TrainServiceAPI.DTO.TrainDTO;
using TrainServiceAPI.Models;

namespace TrainServiceAPI.DTO.VehicleDTO
{
    public class VehicleResponseDTO
    {
        public VehicleResponseDTO(VehicleModels vehicleModels) {
            Id = vehicleModels.Id;
            TipoDeVeiculo = vehicleModels.TipoDeVeiculo;
            CodVeiculo = vehicleModels.CodVeiculo;
            Trens = vehicleModels.Trens?.Select((trainModels) => new TrainResponseExcludingVehicles(trainModels)).ToList();
        }
    public int Id { get; set; }
    public string TipoDeVeiculo { get; set; }
    public int CodVeiculo { get; set; }
    public ICollection<TrainResponseExcludingVehicles>? Trens { get; set; }
    }
}
