using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusClasses
{
    public class Choice
    {
        public RouteValue Route;
        public Card Card;

        public override string ToString()
        {
            return string.Format("{0} => {1}", Route.ToString(), Card.ToShortString());
        }
    }
}
