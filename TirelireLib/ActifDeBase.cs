using System.Text.Json.Serialization;

namespace TirelireLib
{
    public abstract class ActifDeBase
    {
        [JsonInclude]
        public decimal MontantTotal { get; protected set; }
    }
}
