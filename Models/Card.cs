using Newtonsoft.Json;

namespace DeckOfCardsWebApp.Models
{
    public class Card
    {
        [JsonProperty("suit")]
        public string Suit {  get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        public bool IsKept { get; set; }
    }
}
