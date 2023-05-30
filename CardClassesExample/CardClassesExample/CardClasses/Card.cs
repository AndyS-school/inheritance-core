using System;

namespace CardClasses
{
    public class Card
    {
        private static string[] values = { "", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };
        private static string[] suits = { "", "Clubs", "Diamonds", "Hearts", "Spades" };
        private static Random generator = new Random();

        private int value;
        private int suit;

        public Card()
        {
            value = generator.Next(1, 14);
            suit = generator.Next(1, 5);
        }

        public Card(int v, int s)
        {
            this.value = v;
            this.suit = s;
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public int Suit
        {
            get { return suit; }
            set { this.suit = value; }
        }

        public bool IsRed()
        {
            return !IsBlack();
        }

        public bool IsBlack()
        {
            if (IsSpades() || IsClubs())
            {
                return true;
            }
            else
                return false;
        }

        public bool IsFace()
        {
            switch (value)
            {
                case 11: case 12: case 13:
                    return true;
                default: return false;
            }
        }

        public bool IsAce()
        {
            if (value == 1)
                return true;
            else
                return false;
        }

        public bool IsClubs()
        {
            if (suit == 1)
                return true;
            else
                return false;
        }

        public bool IsDiamonds()
        {
            if (suit == 2)
                return true;
            else
                return false;
        }

        public bool IsHearts()
        {
            if (suit == 3)
                return true;
            else
                return false;
        }

        public bool IsSpades()
        {
            if (suit == 4)
                return true;
            else
                return false;
        }

        public bool HasMatchingValue(Card other)
        {
            if (this.value == other.value)
                return true;
            else
                return false;
        }

        public bool HasMatchingSuit(Card other)
        {
            if (this.suit == other.suit)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return values[value] + " of " + suits[suit];
        }
    }
}
