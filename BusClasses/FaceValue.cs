using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusClasses
{
    public enum FaceValue
    {
        [FaceValue(IsPictureCard = true)]
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        [FaceValue(IsPictureCard = true)]
        Jack = 11,
        [FaceValue(IsPictureCard = true)]
        Queen = 12,
        [FaceValue(IsPictureCard = true)]
        King = 13
    }
}
