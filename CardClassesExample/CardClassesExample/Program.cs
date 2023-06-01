﻿using System;
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

            Console.ReadLine();
        }
        /*
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
        */
        //generates and instantly shuffles the deck before returning
        public Deck GenDeck()
        {
            Deck d = new Deck();
            d.Shuffle();
            return d;
        }
        public BJHand GenPlayerHand(Deck d)
        {
            d.Shuffle();
            BJHand playerHand = new BJHand(d, 2);
            return playerHand;
        }
        public BJHand GenComputerHand(Deck d)
        {
            d.Shuffle();
            BJHand computerHand = new BJHand(d, 2);
            return computerHand;
        }
        //methods to check if player/comp has busted
        public bool PlayerBust(BJHand playerHand)
        {
            return playerHand.IsBusted();
        }
        public bool ComputerBust(BJHand computerHand)
        {
            return computerHand.IsBusted();
        }
        //methods to check player/comp scores
        public int PlayerScore(BJHand playerHand)
        {
            return playerHand.Score();
        }
        public int ComputerScore(BJHand computerHand)
        {
            return computerHand.Score();
        }
    }
}
