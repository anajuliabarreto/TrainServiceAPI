namespace TrainServiceAPI.Models
{
    public class UserModels
    {
        public int Id { get; set; }
        public required string NomeUsuario { get; set; }
        public required string SenhaUsuario { get; set; }
    }
}
