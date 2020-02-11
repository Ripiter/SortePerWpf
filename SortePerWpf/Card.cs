using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerWpf
{
    public enum CardNumber
    {
        Two,
        Tree,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        BlackPer,
        Jack,
        Queen,
        King,
        Ace
    }
    public enum CardType
    {
        Spades,
        Diamonds,
        Hearts,
        Clubs
    }
    public enum CardColor
    {
        Red,
        Black
    }


    class Card
    {
        private CardNumber number;
        private CardType type;
        private CardColor color;

        public Card(int number, int type, int color)
        {
            Number = (CardNumber)number;
            Type = (CardType)type;
            Color = (CardColor)color;
        }

        public CardNumber Number { get => number; set => number = value; }
        public CardType Type { get => type; set => type = value; }
        public CardColor Color { get => color; set => color = value; }
    }
}
