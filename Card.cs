using System;
using System.Collections.Generic;

namespace cards
{

    public enum Suit
    {
        Diamonds,
        Clubs,
        Hearts,
        Spades,
    };

    public class Card 
    {

        public string stringVal { get; set; }
        public Suit suit { get; set; }
        public int val { get; set; }
        public int blackJackVal { get; set; }
        private string suitChar { get; set; }
        public string name { get; set; }

        public Card(Suit suit, int val)
        {
            this.suit = suit;
            this.val = val;
            this.blackJackVal = val;
            
            

            switch (val)
            {
                case 1:
                    this.stringVal = "A";
                    this.blackJackVal = 11;
                    break;
                case 2:
                    this.stringVal = "2";
                    
                    break;
                case 3:
                    this.stringVal = "3";
                    break;
                case 4:
                    this.stringVal = "4";
                    break;
                case 5:
                    this.stringVal = "5";
                    break;
                case 6:
                    this.stringVal = "6";
                    break;
                case 7:
                    this.stringVal = "7";
                    break;
                case 8:
                    this.stringVal = "8";
                    break;
                case 9:
                    this.stringVal = "9";
                    break;
                case 10:
                    this.stringVal = "10";
                    break;
                case 11:
                    this.stringVal = "J";
                    this.blackJackVal = 10;
                    break;
                case 12:
                    this.stringVal = "Q";
                    this.blackJackVal = 10;
                    break;
                case 13:
                    this.stringVal = "K";
                    this.blackJackVal = 10;
                    break;
                default:
                    this.stringVal = null;
                    break;
            }

            switch (suit)
            {
                case Suit.Clubs:
                    this.suitChar = "\u2663";
                    break;
                case Suit.Hearts:
                    this.suitChar = "\u2665";
                    break;
                case Suit.Diamonds:
                    this.suitChar = "\u2666";
                    break;
                case Suit.Spades:
                    this.suitChar = "\u2660";
                    break;
            }

            this.name = "[" + this.stringVal + this.suitChar + "]";
        }

        public void Print()
        {
            Console.WriteLine(this.stringVal + " " + this.suit);
        }
    }
}