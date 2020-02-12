using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerWpf
{
    class NormalPlayingCards : IFactory
    {
        public List<ImageCard> GenerateImageCards(List<Card> cards)
        {
            string path = string.Empty;
            List<ImageCard> displayCards = new List<ImageCard>();

            foreach (Card item in cards)
            {
                path = "/Assets/" + item.ToString() + ".png";
                ImageCard imgCard = new ImageCard(path, item);
                displayCards.Add(imgCard);
            }
            return displayCards;
        }
    }
}
