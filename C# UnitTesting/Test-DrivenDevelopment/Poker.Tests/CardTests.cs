namespace Poker.Tests
{
    using System;    
    using NUnit.Framework;

    [TestFixture]
    public class CardTests
    {
        [TestCase(4,1)]
        [TestCase(10,3)]
        [TestCase(12,4)]
        [TestCase(14,2)]
        public void Card_ToStringMethod_ShouldReturnCorrectly(int face, int suit)
        {
            var card = new Card((CardFace)face, (CardSuit)suit);

            string stringCard = $"{((CardFace)face).ToString()} of {((CardSuit)suit).ToString()}";

            Assert.AreEqual(card.ToString(), stringCard);
        }
        
    }
}
