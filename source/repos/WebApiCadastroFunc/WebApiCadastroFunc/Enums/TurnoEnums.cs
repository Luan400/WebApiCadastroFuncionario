using System.Text.Json.Serialization;

namespace WebApiCadastroFunc.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnums
    {
        Manha,
        Tarde,
        Noite
    }
}
