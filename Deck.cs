using System;
using System.Collections.Generic;

namespace cards
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();

        public Deck() 
        {
            Reset();
        }

        public void Reset() 
        {
            cards.Clear();
            foreach (Suit aSuit in Enum.GetValues(typeof(Suit))) 
            {
                for (int val = 1; val <= 13; val++) {
                    cards.Add(new Card(aSuit, val));
                }
            }
        }

        public Card Deal() 
        {
            Card temp = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return temp;
        }

        public void Shuffle()
        {
            Random rand = new Random();
            int n = cards.Count;

            while (n > 1)
            {
                int k = rand.Next(n--);
                Card temp = cards[k];
                cards[k] = cards[n];
                cards[n] = temp;
            }
        }
    }
}