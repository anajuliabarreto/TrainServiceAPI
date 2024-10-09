using System.Text.Json.Serialization;

namespace TrainServiceAPI.Models
{
    public class VehicleModels
    {
        public int Id { get; set; }
        public required string TipoDeVeiculo { get; set; }
        public required int CodVeiculo { get; set; }
        public int? TrainId { get; set; } //Pode ser nulo pois posso criar um veículo sem vincular a algum trem
        [JsonIgnore]
        public TrainModels? Train { get; set; }

        //public int RelationVehicles Status { get; set; }
    }
}
