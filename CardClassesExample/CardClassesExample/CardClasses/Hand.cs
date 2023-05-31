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
        private List<Card> cards = new List<Card>();

        public Hand(int handLimit)
        {
            // 13 values
            for (int i = 1; i <= handLimit; i++)
                Deal();
        }

        // read-only property
        public int NumCards
        {
            get
            {
                return cards.Count;
            }
        }

        // read-only property
        public bool IsEmpty
        {
            get
            {
                return (cards.Count == 0);
            }
        }

        public Card this[int i]
        {
            get
            {
                return cards[i];
            }
        }

        //checks your hand if there's a card equal to the query and returns true/false depending if it's there or not
        public bool EqualTo(object obj, int suit, int value)
        {
            bool equal = false;

            return equal;
        }

        //checks you hand for a given card and tells you it's index if it's there
        public int GetCardIndex(object obj, int suit, int value)
        {
            int i = 0;

            return i;
        }

        // removes a card from the hand based on it's index
        public void Discard(int discardIndex)
        {
                Card c = cards[discardIndex];
                cards.Remove(c);
        }

        public void Shuffle()
        {
            Random gen = new Random();
            // go through all of the cards in the deck
            for (int i = 0; i < NumCards; i++)
            {
                // generate a random index
                int rnd = gen.Next(0, NumCards);
                // swap the card at the random index with the card at the current index
                Card c = cards[rnd];
                cards[rnd] = cards[i];
                cards[i] = c;
            }
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
