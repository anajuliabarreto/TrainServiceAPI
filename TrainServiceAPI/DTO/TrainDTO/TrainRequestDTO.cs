using TrainServiceAPI.DTO.VehicleDTO;

namespace TrainServiceAPI.DTO.TrainDTO
{
    public class TrainRequestDTO
    {
        public required string LocalDeOrigem { get; set; }
        public required int NumeroTrem { get; set; }
        public required string LocalDeDestino { get; set; }
        public required string Ferrovia { get; set; }
        public DateTime DataHoraPartida { get; set; }
        public List<int>? CodVeiculos { get; set; }
    }
}
