using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        public int Count => Cards.Count;

        private readonly List<ICard> cards;
        public IReadOnlyCollection<ICard> Cards => cards.AsReadOnly();

        public CardRepository()
        {
            cards = new List<ICard>();
        }

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }
            if (cards.Any(c => c.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            cards.Add(card);
        }

        public ICard Find(string name) => cards.FirstOrDefault(c => c.Name == name);

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }
            return cards.Remove(card);
        }
    }
}
