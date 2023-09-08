using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingCardGame
{
    public enum CardName
    {
        two, three, four, five, six, seven, eight, nine, ten, jack, queen, king, ace, unknown
    }
    
    public enum CardSuite
    {
        club, spade, diamond, heart, unknown
    }
    public class Card
    {
        public CardName Name { get; set; }
        public CardSuite Suite { get; set; }
        private Card()
        {
            this.Name = CardName.unknown;
            this.Suite = CardSuite.unknown;
        }
        public Card(CardName name, CardSuite suite)
        {
            this.Name = name;
            this.Suite = suite;
        }

        public (CardName name, CardSuite suite) attrs()
        {
            return (Name, Suite);
        }

        public bool IsTenCard()
        {
            return this.Name == CardName.jack
                || this.Name == CardName.queen
                || this.Name == CardName.king
                || this.Name == CardName.ten;
        }
        public int Value()
        {
            switch (Name)
            {
                case CardName.ace: return 1;
                case CardName.two:return 2;
                case CardName.three:return 3;
                case CardName.four:return 4;
                case CardName.five:return 5;
                case CardName.six:return 6;
                case CardName.seven:return 7;
                case CardName.eight:return 8;
                case CardName.nine:return 9;
                case CardName.ten:return 10;
                case CardName.jack:return 10;
                case CardName.queen:return 10;
                case CardName.king:return 10;
                    default: return 0;
            }
        }
    }
}
