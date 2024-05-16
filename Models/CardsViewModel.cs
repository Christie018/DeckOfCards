using Newtonsoft.Json;
namespace DeckOfCardsWebApp.Models
{
    public class CardsViewModel
    {
        [JsonProperty("cards")]
        public List<Card> Cards { get; set; }
        [JsonProperty("deck_id")]
        public string DeckId { get; set; }
        [JsonProperty("remaining")]
        public int Remaining {  get; set; }
    }
}
