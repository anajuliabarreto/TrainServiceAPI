// A classe que vai ser mapeada e servir como base para tabela de trens 
using System.Text.Json.Serialization;

namespace TrainServiceAPI.Models
{
    public class VehicleModels
    {
        public int Id { get; set; }
        public required string TipoDeVeiculo { get; set; }
        public required int CodVeiculo { get; set; }

        [JsonIgnore]
        public ICollection<TrainModels>? Trens { get; set; }

        //public int RelationVehicles Status { get; set; }
    }
}
