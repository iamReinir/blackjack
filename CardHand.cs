namespace CountingCardGame
{

    internal static partial class Blackjack
    {
        class CardHand
        {
            private List<Card> currentHand = new List<Card>();
            private int? value = 0;
            private int aceCount = 0;
            public CardHand(params Card[] cards)
            {
                foreach (Card card in cards)
                {
                   Deal(card);
                }
            }
            public bool Deal(Card card)
            {
                if (value > maxPoint)
                    return false;
                currentHand.Add(card);
                if (card.Name == CardName.ace) aceCount++;
                value = null;
                return true;
            }

            public bool IsNatural()
            {
                if (aceCount != 1 || currentHand.Count != 2) return false;
                return currentHand[0].IsTenCard() || currentHand[1].IsTenCard();
            }
            public int Score()
            {
                if(IsNatural()) { return maxPoint; }
                if(value != null) { return (int)value; }
                if(currentHand.Count == 0) { return 0; }       
                
                int res = 0;
                foreach (var item in currentHand)
                {
                    res += item.Value();
                }
                int ace = aceCount;
                while (ace > 0 && res < maxPoint + 10) {
                    res += 10;
                    -- ace;
                }                
                return res;                
            }

            public string AllCards()
            {
                string res = "";
                foreach(var item in currentHand)
                {
                    res += $"the {item.Name} of {item.Suite}, ";
                }
                return res;
            }
        }
    }
}
