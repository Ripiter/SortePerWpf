using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerWpf
{
    class Human : Player
    {
        public Human(string name) : base(name)
        {

        }

        public override string TakeCard(Player player, int cardNumber)
        {
            return base.TakeCard(player, cardNumber - 1);
        }
    }
}
