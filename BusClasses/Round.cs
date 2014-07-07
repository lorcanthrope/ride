using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusClasses
{
    public class Round
    {
        public Deck Deck;

        public Row First;
        public Row Second;
        public Row Third;
        public Row Fourth;
        public Row Fifth;

        public Round()
        {
            Deck = new Deck(true);

            First = new Row(Deck.Draw());
            
            Second = new Row(Deck.Draw(), Deck.Draw());
            First.AddNextRow(Second);
            Second.AddPreviousRow(First);

            Third = new Row(Deck.Draw(), Deck.Draw(), Deck.Draw());
            Second.AddNextRow(Third);
            Third.AddPreviousRow(Second);

            Fourth = new Row(Deck.Draw(), Deck.Draw());
            Third.AddNextRow(Fourth);
            Fourth.AddPreviousRow(Third);

            Fifth = new Row(Deck.Draw());
            Fourth.AddNextRow(Fifth);
            Fifth.AddPreviousRow(Fourth);
        }

        public int CardsNeeded
        {
            get
            {
                return First.CardsNeeded + Second.CardsNeeded + Third.CardsNeeded + Fourth.CardsNeeded + Fifth.CardsNeeded;
            }
        }

        public bool RoundFinished
        {
            get { return !Deck.HasCardsRemaining || Deck.CardsRemaining < CardsNeeded; }
        }

        
        public TakeRoundResult TakeRound()
        {
            bool finished = false;
            Dictionary<int, Choice> choices = new Dictionary<int, Choice>();

            Choice choice = First.DrawCard();
            choices[0] = choice;
            if(!choice.Card.IsPictureCard)
            {
                choice = Second.DrawCard();
                choices[1] = choice;
                if(!choice.Card.IsPictureCard)
                {
                    choice = Third.DrawCard();
                    choices[2] = choice;
                    if(!choice.Card.IsPictureCard)
                    {
                        choice = Fourth.DrawCard();
                        choices[3] = choice;
                        if(!choice.Card.IsPictureCard)
                        {
                            choice = Fifth.DrawCard();
                            choices[4] = choice;
                            if(!choice.Card.IsPictureCard)
                            {
                                finished = true;
                            }
                        }
                    }
                }
            }
            
            if(Deck.CardsRemaining >= CardsNeeded)
            {
                while (First.NeedsCards) First.AddCard(Deck.Draw());
                while (Second.NeedsCards) Second.AddCard(Deck.Draw());
                while (Third.NeedsCards) Third.AddCard(Deck.Draw());
                while (Fourth.NeedsCards) Fourth.AddCard(Deck.Draw());
                while (Fifth.NeedsCards) Fifth.AddCard(Deck.Draw());
            }

            return new TakeRoundResult
            {
                Choices = choices,
                Finished = finished
            };
        }
    }
}
