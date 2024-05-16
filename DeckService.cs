using DeckOfCardsWebApp.Models;
using Newtonsoft.Json;

namespace DeckOfCardsWebApp
{
    public class DeckService
    {
        private readonly HttpClient _httpClient;

        public DeckService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string CreateNewDeck()
        {
            string url = "https://deckofcardsapi.com/api/deck/new/shuffle";
            HttpResponseMessage response = _httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Deck deck = JsonConvert.DeserializeObject<Deck>(data);
                return deck.DeckId;
            }
            else
            {
                return "";
            }
        }

        public CardsViewModel DrawCards(string deckId, int count)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count={count}";
            HttpResponseMessage response = _httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                CardsViewModel viewModel = JsonConvert.DeserializeObject<CardsViewModel>(data);
                return viewModel;
            }
            else
            {
                return new CardsViewModel();
            }
        }
    }
}
