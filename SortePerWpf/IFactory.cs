using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerWpf
{
    interface IFactory
    {
        List<ImageCard> GenerateImageCards(List<Card> cards);
    }
}
