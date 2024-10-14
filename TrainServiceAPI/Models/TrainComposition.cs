namespace TrainServiceAPI.Models
{
    public class TrainComposition
    {
        public int Id { get; set; }

        public int TremId { get; set; } // Chave estrangeira para TrainModels
        public TrainModels Trens { get; set; } // Navegação para TrainModels

        public int VeiculoId { get; set; } // Chave estrangeira para VehicleModels
        public VehicleModels Veiculos { get; set; } // Navegação para VehicleModels
    }
}
