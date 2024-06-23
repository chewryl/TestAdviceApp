using Newtonsoft.Json;

namespace AdviceAPI.Models
{
    public class AdviceReponse
    {
        [JsonProperty("slip")]
        public Slip Slip { get; set; }
    }

    public class Slip
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("advice")]
        public string Advice { get; set; }
    }
}
