//Conversão dos dados internos do models para este objeto reponse e depois define as propriedades

using TrainServiceAPI.DTO.VehicleDTO;
using TrainServiceAPI.Models;

namespace TrainServiceAPI.DTO.TrainDTO
{
    public class TrainResponseDTO
    {
        public TrainResponseDTO(TrainModels trainModels) 
        {
            Id = trainModels.Id;
            NumeroTrem = trainModels.NumeroTrem;
            LocalDeOrigem = trainModels.LocalDeOrigem;
            LocalDeDestino = trainModels.LocalDeOrigem;
            DataHoraPartida = trainModels.DataHoraPartida;
            Veiculos = trainModels.Veiculos?.Select((vehicle) => new VehicleResponseExcludingTrains(vehicle)).ToList();
        }
        public DateTime DataHoraPartida { get; set; }
        public string LocalDeOrigem { get; set; }
        public string LocalDeDestino { get; set; }        
        public int Id { get; set; }
        public int NumeroTrem { get; set; }
        public List<VehicleResponseExcludingTrains>? Veiculos { get; set; }
    }
}

