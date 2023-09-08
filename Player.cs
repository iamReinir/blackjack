namespace CountingCardGame
{
    internal static partial class Blackjack
    {
        public class Player
        {
            CardHand hand = new();
            public Player() { }
            public bool Busted()
            {
                return hand.Score() > maxPoint;
            }

            public bool Deal(Card card) { return hand.Deal(card); }
            public int Score() { return hand.Score(); }

            public bool Natural() { return hand.IsNatural(); }

            public string AllCards()
            {
                return hand.AllCards();
            }
        }     
    }
}
