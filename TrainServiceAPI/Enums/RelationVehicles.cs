using System.ComponentModel;

namespace TrainServiceAPI.Enums
{
    public enum RelationVehicles
    {
        [Description ("Sem relacioamento")]
        SemRelacionamento = 1,
        [Description ("Em andamento")]
        EmAndamento = 2,
        [Description ("Concluído")]
        Concluido = 3,
    }
}
