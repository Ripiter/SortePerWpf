using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerWpf
{
    abstract class Player
    {
        List<Card> playersCard = new List<Card>();
        string name;

        public List<Card> PlayersCards
        {
            get
            {
                return this.playersCard;
            }
            set
            {
                this.playersCard = value;
            }
        }
        public string Name { get => name; set => name = value; }

        public Player(string name)
        {
            this.Name = name;
        }

      


        public string RemovePairs(Card cardFromPlayer)
        {
            string temp = string.Empty;
            foreach (Card card in PlayersCards.ToList())
            {
                if (card.Number == cardFromPlayer.Number && card.Type != cardFromPlayer.Type)
                {
                    temp += "Match " + card.Number + " " + card.Type + "\n" +
                            "with " + cardFromPlayer.Number + " " + cardFromPlayer.Type;

                    PlayersCards.Remove(card);
                    PlayersCards.Remove(cardFromPlayer);
                }
            }
            return temp;
        }


        public virtual string RemoveAllPairs()
        {
            string temp = string.Empty;
            foreach (Card nCard in PlayersCards.ToList())
            {
                foreach (Card card in PlayersCards.ToList())
                {
                    if (card.Number == nCard.Number && card.Type != nCard.Type)
                    {
                        temp += "Card from " + this.Name + " removed " + card.Number + " " + card.Type + "\n" +
                                "Card from " + this.Name + " removed " + nCard.Number + " " + nCard.Type + "\n\n";

                        //removes pair
                        PlayersCards.Remove(nCard);
                        PlayersCards.Remove(card);
                    }
                }
            }
            return temp;
        }
    }
}
