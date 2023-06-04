using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
        // can instantiate the list here OR in the constructor
        protected List<Card> cards = new List<Card>();

        public Hand() { }

        public Hand(Deck d, int maxHand)
        {
            for(int i = 0; i < maxHand; i++)
            {
                Card c = d.Deal();
                cards.Add(c);
            }
        }

        public void AddCard(int value, int suit)
        {
            cards.Add(new Card(value, suit));
        }

        public void AddCard(Deck d)
        {
            cards.Add(d.Deal());
        }

        // read-only property
        public int NumCards
        {
            get
            {
                return cards.Count;
            }
        }

        //checks your hand if there's a card equal to the query and returns true/false depending if it's there or not
        public bool EqualTo(Card c)
        {
            bool match = false;
            foreach(Card d in cards)
            {
                if (c.GetHashCode() == d.GetHashCode())
                    match = true;
            }
            return match;
        }
        //checks your hand if you have a card equal in value to the query
        public bool EqualTo(int value)
        {
            bool match = false;
            foreach (Card c in cards)
            {
                if (c.Value == value)
                    match = true;
            }
            return match;
        }
        //check your hand to see if you have a card that matches both query value and suit
        public bool EqualTo(int value, int suit)
        {
            bool match = false;
            foreach (Card c in cards)
            {
                if (c.Value == value && c.Suit == suit)
                    match = true;
            }
            return match;
        }

        //checks you hand for a given card and tells you it's index if it's there
        public int IndexOf(Card c)
        {
            int index = cards.IndexOf(c);
            return index;
        }
        
        public int IndexOf(int value)
        {
            int i = -1;
            foreach(Card c in cards)
            {
                if(c.Value == value)
                {
                    i = cards.IndexOf(c);
                }
            }
            return i;
        }

        public int IndexOf(int value, int suit)
        {
            int i = -1;
            foreach (Card c in cards)
            {
                if (c.Value == value && c.Suit == suit)
                {
                    i = cards.IndexOf(c);
                }
            }
            return i;
        }
        
        // removes a card from the hand based on it's index
        public Card Discard(int discardIndex)
        {
                Card c = cards[discardIndex];
                cards.Remove(c);
                return c;
        }

        //tells you what the card in a given index is
        public Card GetCard(int cardIndex)
        {
            Card c = cards[cardIndex];
            return c;
        }

        public override string ToString()
        {
            string output = "";
            // go through every card in the hand
            foreach (Card c in cards)
                // ask the card to convert itself to a string
                output += (c.ToString() + "\n");
            return output;
        }
    }
}
