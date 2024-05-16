using DeckOfCardsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCardsWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly DeckService _deckService;

        public HomeController(DeckService deckService)
        {
            _deckService = deckService;
        }

        public IActionResult Index()
        {
            var deckId = _deckService.CreateNewDeck();
            ViewBag.TheIdForTheShuffledDeck = deckId;
            return View();
        }

        public IActionResult DrawCards(string deckId, int count)
        {
            CardsViewModel cards = _deckService.DrawCards(deckId, count);
            return View(cards);
        }

        [HttpPost]
        public IActionResult DrawCards(CardsViewModel model, int count)
        {
            var keptCards = model.Cards.Where(c => c.IsKept).ToList();

            int cardsToDraw = count - keptCards.Count;
            var newCardViewModel = _deckService.DrawCards(model.DeckId, cardsToDraw);
            keptCards.AddRange(newCardViewModel.Cards);
            model.Cards = keptCards;
            return View(model);

        }
      
    }
}
