using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusClasses
{
    public sealed class Row
    {
        private readonly RowValue RowValue;
        private Row PreviousRow;
        private Row NextRow;

        public readonly Dictionary<RouteValue, Card> Contents = new Dictionary<RouteValue, Card>();

        public Row(Card centreCard)
        {
            RowValue = RowValue.One;
            Contents[RouteValue.Centre] = centreCard;            
        }

        public Row(Card leftCard, Card rightCard)
        {
            RowValue = RowValue.Two;
            Contents[RouteValue.Left] = leftCard;
            Contents[RouteValue.Right] = rightCard;
        }

        public Row(Card leftCard, Card centreCard, Card rightCard)
        {
            RowValue = RowValue.Three;
            Contents[RouteValue.Left] = leftCard;
            Contents[RouteValue.Centre] = centreCard;
            Contents[RouteValue.Right] = rightCard;
        }

        public void AddPreviousRow(Row row)
        {
            PreviousRow = row;
        }

        public void AddNextRow(Row row)
        {
            NextRow = row;
        }
        
        public IEnumerable<RouteValue> EmptyRoutes
        {
            get
            {
                return AvailableRoutes.Except(Contents.Where(c => c.Value != null).Select(c => c.Key));
            }
        }

        public bool NeedsCards
        {
            get { return !Contents.Where(c => c.Value != null).Select(c => c.Key).SequenceEqual(AvailableRoutes); }
        }

        public int CardsNeeded
        {
            get { return EmptyRoutes.Count(); }
        }

        public void AddCard(Card card)
        {            
            Contents[EmptyRoutes.OrderBy(a => Guid.NewGuid()).FirstOrDefault()] = card;
        }

        public Choice DrawCard()
        {
            RouteValue routeChosen = AvailableRoutes.OrderBy(a => Guid.NewGuid()).First();
            Card cardChosen = Contents[routeChosen];
            Contents.Remove(routeChosen);
            return new Choice
            {
                Card = cardChosen,
                Route = routeChosen
            };
        }

        public IEnumerable<RouteValue> AvailableRoutes
        {
            get
            {
                if(RowValue == RowValue.One)
                {
                    return new []{RouteValue.Centre};
                }
                else if(RowValue == RowValue.Two)
                {
                    return new[] {RouteValue.Left, RouteValue.Right};
                }
                else if(RowValue == RowValue.Three)
                {
                    return new[] {RouteValue.Left, RouteValue.Centre, RouteValue.Right};
                }

                return null;
            }
        }
    }
}