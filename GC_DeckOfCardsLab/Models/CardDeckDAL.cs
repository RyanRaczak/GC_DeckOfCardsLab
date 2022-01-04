using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GC_DeckOfCardsLab.Models
{
    public class CardDeckDAL
    {
        string deckID = "cieeprnjy2il";
        string numberToDraw = "5";
        string PileName = "hand";
        public Cards DrawCards()
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/draw/?count={numberToDraw}";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string result = rd.ReadToEnd();

            Cards c = JsonConvert.DeserializeObject<Cards>(result);

            return c;
        }

        public void ReturnAndShuffle()
        {
            //string urlReturn = $"https://deckofcardsapi.com/api/deck/{deckID}/return/";
            //string urlReturnPile = $"https://deckofcardsapi.com/api/deck/{deckID}/pile/{PileName}/return/";
            string urlShuffle = $"https://deckofcardsapi.com/api/deck/{deckID}/shuffle/";

            HttpWebRequest request = WebRequest.CreateHttp(urlShuffle);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }

        public void AddToHand(string[] cards)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/pile/{PileName}/add/?cards=";
            for (int i = 0; i < cards.Length; i++)
            {
                url += $"{cards[i]},"; 
            }
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }

        public CurrentHand ViewHand()
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/pile/{PileName}/list/";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string result = rd.ReadToEnd();
            CurrentHand c = JsonConvert.DeserializeObject<CurrentHand>(result);
            return c;
        }
    }
}
