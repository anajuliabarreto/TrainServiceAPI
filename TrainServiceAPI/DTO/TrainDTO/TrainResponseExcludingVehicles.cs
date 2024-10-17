using TrainServiceAPI.Models;

namespace TrainServiceAPI.DTO.TrainDTO
{
    public class TrainResponseExcludingVehicles
    {
        public TrainResponseExcludingVehicles(TrainModels trainModels) 
        {
                Id = trainModels.Id;
                Ferrovia = trainModels.Ferrovia;
                NumeroTrem = trainModels.NumeroTrem;
                LocalDeOrigem = trainModels.LocalDeOrigem;
                LocalDeDestino = trainModels.LocalDeOrigem;
                DataHoraPartida = trainModels.DataHoraPartida;                
        }
        public string Ferrovia { get; set; }
        public DateTime DataHoraPartida { get; set; }
        public string LocalDeOrigem { get; set; }
        public string LocalDeDestino { get; set; }
        public int Id { get; set; }
        public int NumeroTrem { get; set; }            
    }
}
