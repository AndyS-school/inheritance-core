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

            TestHandConstructor();
            TestAddCard();
            TestRemoveCard();
            TestGetCard();
            TestIndexOf();
            TestEqualTo();
            TestHandToString();

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
            Card two = new Card(1, 2);
            Console.WriteLine("Testing indexer. Obj expect 0: " + c.IndexOf(one));
            Console.WriteLine("Testing indexer. Value + Suit expect 1: " + c.IndexOf(1, 2));
            Console.WriteLine("Testing indexer. Value expect 3: " + c.IndexOf(1));
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
    }
}
