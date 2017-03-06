namespace Poker.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;

    [TestFixture]
    public class HandTests
    {
        private static IList<ICard> cards;
        private static Random generator = new Random();
         
        [SetUp]       
        public void Initialize()
        {
            cards = new List<ICard>();

            for (int i = 0; i < generator.Next(0,10); i++)
            {
                cards.Add(new Card((CardFace)generator.Next(2, 15), (CardSuit)generator.Next(1, 5)));       
            }
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void Hand_ToStringMethod_ShouldReturnCorrectly(int pointless) //cheat to execute all test cases with random setups
        {
            var hand = new Hand(cards);

            string stringHand = string.Join(", ", cards);

            Assert.AreEqual(hand.ToString(), stringHand);
        }

    }
}
