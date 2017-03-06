namespace Deck.Tests
{
    using NUnit.Framework;
    using Santase.Logic;
    using Santase.Logic.Cards;
    using UnitTestTheDeckFromGameEngine;
    using System;

    [TestFixture]    
    public class DeckTests
    {            
        [Test]
        public void Deck_CardsLeft_ShouldReturnNonNegativeInt()
        {
            var deck = new Deck();

            int cardsCount = deck.CardsLeft;

            Assert.LessOrEqual(0, cardsCount);
        }

        [TestCase(2)]
        [TestCase(5)]
        [TestCase(0)]
        public void Deck_GetNextCard_ShouldReduceCardsCountCorrectly(int drawCount)
        {
            var deck = new Deck();
            int oldCount = deck.CardsLeft;

            for (int i = 0; i < drawCount; i++)
            {
                var card = deck.GetNextCard();
            }             
            
            int newCount = deck.CardsLeft;

            Assert.AreEqual(oldCount, newCount + drawCount);
        }

        [Test]
        public void Deck_GetNextCard_ShouldThrowException()
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {                
                deck.GetNextCard();
            }
            Assert.Throws<InternalGameException>(() => deck.GetNextCard()); 
        }

        [Test]
        public void Deck_TrumpCard_ShouldNotBeNull()
        {
            var deck = new Deck();

            var trumpCard = deck.TrumpCard;

            Assert.IsNotNull(trumpCard);
        }

        [Test]
        public void Deck_ChangeTrumpCard_ShouldChangeCorrectly()
        {
            var deck = new Deck();
            var card = Card.GetCard(CardSuit.Diamond, CardType.Ace);

            deck.ChangeTrumpCard(card);

            Assert.AreSame(card, deck.TrumpCard);
        }
    }
}
