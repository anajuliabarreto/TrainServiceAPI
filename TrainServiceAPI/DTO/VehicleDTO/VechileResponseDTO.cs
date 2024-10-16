using TrainServiceAPI.DTO.TrainDTO;
using TrainServiceAPI.Models;

namespace TrainServiceAPI.DTO.VehicleDTO
{
    public class VechileResponseDTO
    {
        public VechileResponseDTO(VehicleModels vehicleModels) {
            Id = vehicleModels.Id;
            TipoDeVeiculo = vehicleModels.TipoDeVeiculo;
            CodVeiculo = vehicleModels.CodVeiculo;
            Trens = vehicleModels.Trens?.Select((trainModels) => new TrainResponseExcludingVehicles(trainModels)).ToList();
        }
    public int Id { get; set; }
    public required string TipoDeVeiculo { get; set; }
    public required int CodVeiculo { get; set; }
    public ICollection<TrainResponseExcludingVehicles>? Trens { get; set; }
    }
}
