using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusClasses
{
    public sealed class Deck
    {
        private readonly List<Card> Cards = new List<Card>();

        public Deck(bool shuffle = false)
        {
            foreach (SuitValue suitValue in Enum.GetValues(typeof(SuitValue)))
            {
                foreach (FaceValue faceValue in Enum.GetValues(typeof(FaceValue)))
                {
                    Cards.Add(new Card(faceValue, suitValue));
                }
            }            

            if(shuffle) Shuffle();
        }

        public Card Draw()
        {
            Card card = Cards.FirstOrDefault();
            Cards.Remove(card);
            return card;
        }

        public void Shuffle()
        {
            Card[] tempCards = Cards.ToArray();
            Cards.Clear();
            Cards.AddRange(tempCards.OrderBy(a => Guid.NewGuid()));
        }

        public bool HasCardsRemaining
        {
            get { return Cards.Any(); }
        }

        public int CardsRemaining
        {
            get { return Cards.Count; }
        }
    }
}
