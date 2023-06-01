using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class BJHand : Hand
    {
        public BJHand() : base() { }

        public BJHand(Deck d, int maxHand) : base(d, maxHand) { }

        public bool HasAce()
        {
            bool ace = false;
            foreach(Card c in cards)
            {
                if (c.Value == 1)
                    ace = true;
            }
            return ace;
        }

        public bool IsBusted()
        {
            bool bust = false;
            int score = 0;
            foreach (Card c in cards)
            {
                score += c.Value;
            }
            if (score > 21)
                bust = true;
            return bust;
        }

        public int Score()
        {
            int score = 0;
            foreach(Card c in cards)
            {
                score += c.Value;
            }
            return score;
        }
    }
}
