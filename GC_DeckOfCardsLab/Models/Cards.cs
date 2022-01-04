using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_DeckOfCardsLab.Models
{

    public class Cards
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public Card[] cards { get; set; }
        public int remaining { get; set; }
        public List<string> keptCards { get; set; } = new List<string>();
    }

    public class Card
    {
        public string code { get; set; }
        public string image { get; set; }
        public Images images { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
    }

    public class Images
    {
        public string svg { get; set; }
        public string png { get; set; }
    }

}
