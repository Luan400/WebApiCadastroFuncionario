using System.Text.Json.Serialization;

namespace WebApiCadastroFunc.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnums
    {
        RH,
        Financeiro,
        Compras,
        Atendimento,
        Zeladoria
    }
}
