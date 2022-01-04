using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_DeckOfCardsLab.Models
{

    public class CurrentHand
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public int remaining { get; set; }
        public Piles piles { get; set; }
    }

    public class Piles
    {
        public Hand hand { get; set; }
    }

    public class Hand
    {
        public int remaining { get; set; }
        public Card[] cards { get; set; }
    }

}
