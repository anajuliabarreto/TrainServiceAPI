namespace TrainServiceAPI.Models
{
    public class VehicleModels
    {
        public int Id { get; set; }
        public required string TipoDeVeiculo { get; set; }
        public required int CodVeiculo { get; set; }
        public ICollection<TrainModels>? Trens { get; set; }

        //public int RelationVehicles Status { get; set; }
    }
}
