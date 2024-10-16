namespace TrainServiceAPI.DTO.VehicleDTO
{
    public class VehicleRequestDTO
    {
        public required int CodVeiculo { get; set; }
        public required string TipoDeVeiculo { get; set; }
        public List<int>? NumeroTrens { get; set; }
    }
}
