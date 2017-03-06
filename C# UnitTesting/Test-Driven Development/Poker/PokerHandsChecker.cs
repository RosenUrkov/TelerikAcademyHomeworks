using System;
using System.Linq;

namespace Poker
{

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            foreach (var card in hand.Cards)
            {
                if (hand.Cards.Any(x => x.Face == card.Face && x.Suit == card.Suit && !x.Equals(card)))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            //stupid
            int cardFaceCount = 0;

            foreach (var card in hand.Cards)
            {
                foreach (var cardFace in hand.Cards)
                {
                    if (card.Face == cardFace.Face)
                    {
                        cardFaceCount++;
                    }
                }

                if (cardFaceCount >= 4)
                {
                    return true;
                }
                else
                {
                    cardFaceCount = 0;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (hand.Cards.All(x => x.Suit == hand.Cards[0].Suit))
            {
                return !StraightCheck(hand);
            }

            return false;
        }

        private bool StraightCheck(IHand hand)
        {
            int lowestCardFace = hand.Cards.Min(x => (int)x.Face);
            for (int i = lowestCardFace + 1; i < lowestCardFace + 4; i++)
            {
                if (!hand.Cards.Any(x => (int)x.Face == i))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
