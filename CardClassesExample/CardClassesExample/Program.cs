using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardClasses;

namespace CardTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestDeckConstructor();
            //TestDeckShuffle();
            //TestDeckDeal();

            /*
            TestHandConstructor();
            TestAddCard();
            TestRemoveCard();
            TestGetCard();
            TestIndexOf();
            TestEqualTo();
            TestHandToString();
            */
            

            //TestBJAce();
            //TestBJBust();
            //TestBJScore();
            
            //
            //blackjack method
            //
            
            //gens new deck and deals starting cards
            Deck d = GenDeck();
            BJHand computerHand = GenComputerHand(d);
            BJHand playerHand = GenPlayerHand(d);
            Hands(playerHand, computerHand);

            bool noHit = false;
            do
            {
                Console.WriteLine("//////////////////////////////////////////");
                bool pHit = PlayerHit(playerHand, d);
                bool cHit = ComputerHit(computerHand, d);
                Hands(playerHand, computerHand);

                if (pHit == false && cHit == false)
                    noHit = true;
            } while (noHit == false);

            //checks if either player is bust and declairs the other the winner, otherwise checks who has the higher hand, or if it's a tie
            if (playerHand.IsBusted() == true)
                Console.WriteLine("Dealer Wins");
            else if (computerHand.IsBusted() == true)
                Console.WriteLine("Player Wins");
            else if (playerHand.Score() > computerHand.Score())
                Console.WriteLine("Player Wins");
            else if (computerHand.Score() > playerHand.Score())
                Console.WriteLine("Computer Wins");
            else
                Console.WriteLine("Push");

            Console.ReadLine();
            
        }

        static void TestDeckConstructor()
        {
            Deck d = new Deck();

            Console.WriteLine("Testing deck of cards default constructor");
            Console.WriteLine("NumCards.  Expecting 52. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("ToString.  Expect a ton of cards in order.\n" + d.ToString());
            Console.WriteLine();
        }

        static void TestDeckShuffle()
        {
            Deck d = new Deck();
            d.Shuffle();
            Console.WriteLine("Testing deck of cards shuffle");
            Console.WriteLine("NumCards.  Expecting 52. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("First Card will rarely be the Ace of Clubs. " + d[0]);
            Console.WriteLine("ToString.  Expect a ton of cards in shuffled order.\n" + d.ToString());
            Console.WriteLine();
        }

        static void TestDeckDeal()
        {
            Deck d = new Deck();
            Card c = d.Deal();

            Console.WriteLine("Testing deck of cards deal");
            Console.WriteLine("NumCards.  Expecting 51. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("Dealt Card should be Ace of Clubs. " + c);

            // now let's deal them all and see what happens at the end
            for (int i = 1; i <= 51; i++)
                c = d.Deal();
            Console.WriteLine("Dealt all 52 cards");
            Console.WriteLine("NumCards.  Expecting 0. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting true. " + d.IsEmpty);
            Console.WriteLine("Last Card should be King of Spades. " + c);
            Console.WriteLine("Dealing again should return null. Expecting true. " + (d.Deal() == null));

            Console.WriteLine();
        }

        static void TestHandConstructor()
        {
            Deck a = new Deck();
            Hand d = new Hand();

            Console.WriteLine("Testing hand of cards default constructor");
            Console.WriteLine("NumCards.  Expecting 0. " + d.NumCards);
            Console.WriteLine("ToString.  Expect no cards in order.\n" + d.ToString());
            Console.WriteLine();

            Hand c = new Hand(a, 1);

            Console.WriteLine("Testing hand of cards overloaded constructor");
            Console.WriteLine("NumCards.  Expecting 1. " + c.NumCards);
            Console.WriteLine("ToString.  Expect 1 card.\n" + c.ToString());
            Console.WriteLine();
        }

        static void TestAddCard()
        {
            Hand c = new Hand();
            Console.WriteLine("Testing card adding. Expect 0: " + c.NumCards);
            c.AddCard(1, 1);
            Console.WriteLine("Testing card adding. Expect 1: " + c.NumCards);
        }

        static void TestRemoveCard()
        {
            Deck d = new Deck();
            Hand c = new Hand(d, 1);
            Console.WriteLine("Testing card removing. Expect 1: " + c.NumCards);
            Console.WriteLine("Removed Card: " + c.Discard(0));
            Console.WriteLine("Testing card removing. Expect 0: " + c.NumCards);
        }

        static void TestGetCard()
        {
            Deck d = new Deck();
            Hand c = new Hand(d, 1);
            Console.WriteLine("Testing card getting. Gotten Card: " + c.GetCard(0));
        }

        static void TestIndexOf()
        {
            Deck d = new Deck();
            Hand c = new Hand(d, 3);
            Card one = new Card(1, 1);
            Console.WriteLine("Testing indexer. Obj expect 0: " + c.IndexOf(one));
            
            Console.WriteLine("Testing indexer. Value + Suit expect 1: " + c.IndexOf(1, 2));
            //in this implementation, the indexer will return of the latest card in the hand with the proper value
            Console.WriteLine("Testing indexer. Value expect 2: " + c.IndexOf(1));
            Console.WriteLine("Testing indexer. Card that does not exist expect -1: " + c.IndexOf(9));
        }

        //HasCard in mary's screencast, just a differant name
        static void TestEqualTo()
        {
            Deck d = new Deck();
            Hand c = new Hand(d, 3);
            Card one = new Card(1, 1);
            Card nine = new Card(9, 4);
            Console.WriteLine("Testing EqualTo. Obj expect true: " + c.EqualTo(one));
            Console.WriteLine("Testing EqualTo. Obj expect false: " + c.EqualTo(nine));
            Console.WriteLine("Testing EqualTo. Value + Suit expect true: " + c.EqualTo(1,2));
            Console.WriteLine("Testing EqualTo. Value + Suit expect false: " + c.EqualTo(9, 4));
            Console.WriteLine("Testing EqualTo. Value expect true: " + c.EqualTo(1));
            Console.WriteLine("Testing EqualTo. Value expect false: " + c.EqualTo(9));
        }

        static void TestHandToString()
        {
            Deck d = new Deck();
            Hand c = new Hand(d, 7);
            Console.WriteLine("Testing hand ToString. Expect 7 cards: /n" + c.ToString());
        }

        static void TestBJAce()
        {
            BJHand c = new BJHand();
            c.AddCard(1, 1);
            BJHand b = new BJHand();
            b.AddCard(9, 4);
            Console.WriteLine("Testing Black Jack Ace. Expect true: " + c.HasAce());
            Console.WriteLine("Testing Black Jack Ace. Expect false: " + b.HasAce());
            c.ToString();
            b.ToString();
        }

        static void TestBJBust()
        {
            BJHand c = new BJHand();
            c.AddCard(10, 1);
            c.AddCard(10, 2);
            c.AddCard(10, 3);

            BJHand b = new BJHand();
            b.AddCard(1, 1);
            b.AddCard(10, 2);
            b.AddCard(10, 3);

            Console.WriteLine("Testing BJ bust. Expect true: " + c.IsBusted());
            Console.WriteLine("Testing BJ bust. Expect false: " + b.IsBusted());
        }

        static void TestBJScore()
        {
            BJHand c = new BJHand();
            c.AddCard(10, 1);
            c.AddCard(10, 2);
            c.AddCard(10, 3);

            BJHand b = new BJHand();
            b.AddCard(1, 1);
            b.AddCard(10, 2);
            b.AddCard(10, 3);

            Console.WriteLine("Testing BJ Score. Expect 30: " + c.Score());
            Console.WriteLine("Testing BJ Score. Expect 21: " + b.Score());
        }
        

        //
        // Problem 3 methods
        //
        //generates and instantly shuffles the deck before returning
        public static Deck GenDeck()
        {
            Deck d = new Deck();
            d.Shuffle();
            return d;
        }
        //makes the stating hands
        public static BJHand GenPlayerHand(Deck d)
        {
            BJHand playerHand = new BJHand(d, 2);
            return playerHand;
        }
        public static BJHand GenComputerHand(Deck d)
        {
            BJHand computerHand = new BJHand(d, 2);
            return computerHand;
        }

        //asks if the player wants to hit
        public static bool PlayerHit(BJHand playerHand, Deck d)
        {
            bool hit = false;
            //checks if player is busted, if so sends a message and instantly returns no hit
            if (playerHand.IsBusted() == false)
            {
                Console.WriteLine("Would you like to hit? y/n");
                string s = Console.ReadLine();
                //loop to validate input so if anything but y or n is entered, you have to try again
                bool answered = false;
                do
                {
                    if (s == "y")
                    {
                        Console.WriteLine("Here you are then.");
                        playerHand.AddCard(d);
                        hit = true;
                        answered = true;
                    }

                    else if (s == "n")
                    {
                        Console.WriteLine("As you like.");
                        answered = true;
                    }

                    else
                    {
                        Console.WriteLine("What's that?");
                    }
                } while (answered == false);

            }
            else
                Console.WriteLine("You're Busted!");

            return hit;
        }
        //computer always hits iff it's hand is less than 12
        public static bool ComputerHit(BJHand computerHand, Deck d)
        {
            bool hit = false;
            //no need to check is computer is bust becuase that auto fails the less than 13 condition
            if(computerHand.Score() <= 13)
            {
                Console.WriteLine("Computer hits.");
                computerHand.AddCard(d);
                hit = true;
            }
            else
            {
                Console.WriteLine("Computer does not hit.");
            }
            if (computerHand.IsBusted() == true)
                Console.WriteLine("Computer is Busted!");
            return hit;
        }

        //shows the current hands and scores
        public static void Hands(BJHand playerHand, BJHand computerHand)
        {
            Console.WriteLine();
            Console.WriteLine("Player Hand:");
            Console.WriteLine(playerHand.ToString());
            Console.WriteLine("Total Player Score: " + playerHand.Score());
            Console.WriteLine();
            Console.WriteLine("Computer Hand:");
            Console.WriteLine(computerHand.ToString());
            Console.WriteLine("Total Computer Score: " + computerHand.Score());
        }
    }
}
