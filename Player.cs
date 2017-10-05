using System;
using System.Collections.Generic;

namespace cards
{
    public class Player
    {
        public List<Card> hand = new List<Card>();
        public string name;
        public int score = 0;
        public int purse = 0;
        public int bet = 0;

        public Player(string name, int purse)
        {
            this.name = name;
            this.purse = purse;
        }

        public Card Draw(Card card) 
        {
            hand.Add(card);
            return card;
        }

        public Card Discard(int idx)
        {
            if (idx < 0 || idx >= hand.Count)
            {
                return null;
            }
            Card temp = hand[idx];
            hand.RemoveAt(idx);
            return temp;
        }
    }


}