﻿
using System.Text.Json.Serialization;

namespace TrainServiceAPI.Models
{
    public class TrainModels
    {
        public int Id { get; set; }
        public required string LocalDeOrigem { get; set; }
        public required string LocalDeDestino { get; set; }
        public required int NumeroTrem { get; set; }
        public required string Ferrovia { get; set; }
        public required DateTime DataHoraPartida { get; set; }

        [JsonIgnore]
        public ICollection<TrainComposition>? TremVeiculo { get; set; } // Posso ter veiculos associados 
    }

}