using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusClasses
{
    public class Card
    {
        public FaceValue Face;
        public SuitValue Suit;

        public Card(FaceValue face, SuitValue suit)
        {
            Face = face;
            Suit = suit;
        }

        public override string ToString()
        {
            return string.Format("{0}{1} of {2}", IsPictureCard ? "(P) " : string.Empty, Face.ToString(), Suit.ToString());
        }

        public string ToShortString()
        {
            string suit;

            switch (Suit)
            {
                case SuitValue.Hearts:
                    suit = "♥";
                    break;
                case SuitValue.Diamonds:
                    suit = "♦";
                    break;
                case SuitValue.Clubs:
                    suit = "♣";
                    break;
                case SuitValue.Spades:
                    suit = "♠";
                    break;
                default:
                    suit = Suit.ToString();
                    break;
            }

            string face;

            switch (Face)
            {
                case FaceValue.Ace:
                    face = "A";
                    break;
                case FaceValue.Two:
                    face = "2";
                    break;
                case FaceValue.Three:
                    face = "3";
                    break;
                case FaceValue.Four:
                    face = "4";
                    break;
                case FaceValue.Five:
                    face = "5";
                    break;
                case FaceValue.Six:
                    face = "6";
                    break;
                case FaceValue.Seven:
                    face = "7";
                    break;
                case FaceValue.Eight:
                    face = "8";
                    break;
                case FaceValue.Nine:
                    face = "9";
                    break;
                case FaceValue.Ten:
                    face = "T";
                    break;
                case FaceValue.Jack:
                    face = "J";
                    break;
                case FaceValue.Queen:
                    face = "Q";
                    break;
                case FaceValue.King:
                    face = "K";
                    break;
                default:
                    face = Face.ToString();
                    break;

            }

            return string.Format("{0}{1}", face, suit);
        }

        public bool IsPictureCard
        {
            get
            {
                FaceValueAttribute faceValueAttribute = (FaceValueAttribute)typeof(FaceValue).
                    GetField(Face.ToString()).
                    GetCustomAttributes(typeof(FaceValueAttribute), false).
                    FirstOrDefault();
                if (faceValueAttribute == null) return false;
                return faceValueAttribute.IsPictureCard;
            }
        }
    }
}