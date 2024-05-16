using Newtonsoft.Json;

namespace DeckOfCardsWebApp.Models
{
    public class Deck
    {
        [JsonProperty("deck_id")]
        public string DeckId { get; set; }
    }
}
