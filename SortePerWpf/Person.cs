using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SortePerWpf
{
    class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public Person(string name, string amountOfCards)
        {
            Name = name;
            AmountOfCards = amountOfCards;
        }

        private string amountOfCards;
        public string AmountOfCards
        {
            get { return amountOfCards; }
            set { amountOfCards = value; }
        }


        //private Image hi;

        //public Image MyProperty
        //{
        //    get { return hi; }
        //    set { hi = value; }
        //}





    }
}
