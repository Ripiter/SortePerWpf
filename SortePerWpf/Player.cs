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

        /// <summary>
        /// Takes card from another player
        /// </summary>
        public virtual string TakeCard(Player player, int cardPlace)
        {
            Card card = player.PlayersCards[cardPlace];

            player.PlayersCards.Remove(card);
            int rndPos = new Random(DateTime.Now.Millisecond).Next(0, PlayersCards.Count);
            this.PlayersCards.Insert(rndPos, card);

            return RemovePairs(card);
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
