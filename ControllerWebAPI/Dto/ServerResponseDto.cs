using Newtonsoft.Json;

namespace ControllerWebAPI.Dto
{
    public class ServerResponseDto
    {
        public string Date { get; set; } = string.Empty;
        public int Interval { get; set; }
        public List<ServerMessage> Messages { get; set; } = new List<ServerMessage>();
    }

    public class ServerMessage
    {
        public int Id { get; set; }
        public string? Operation { get; set; }
        public int? Active { get; set; }
        public int? Online { get; set; }
        public int? Direction { get; set; }
        public int? Mode { get; set; }
        public int? Zone { get; set; }
        public string? Begin { get; set; }
        public string? End { get; set; }
        public string? Days { get; set; }
        public int? Open { get; set; }
        [JsonProperty("Open_control")]
        [System.Text.Json.Serialization.JsonPropertyName("Open_control")]
        public int? OpenControl { get; set; }
        [JsonProperty("Close_control")]
        [System.Text.Json.Serialization.JsonPropertyName("Close_control")]
        public int? CloseControl { get; set; }
        public int? Granted { get; set; }
        [JsonProperty("Events_success")]
        [System.Text.Json.Serialization.JsonPropertyName("Events_success")]
        public int? EventsSuccess { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
    }

    public class Card
    {
        [JsonProperty("Card")]
        [System.Text.Json.Serialization.JsonPropertyName("Card")]
        public string? Name { get; set; }
        public int? Flags { get; set; }
        public int? Tz { get; set; }
    }
}
