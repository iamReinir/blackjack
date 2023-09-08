using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingCardGame
{
    internal class CardStack
    {
        public static readonly CardName[] allnames = { 
            CardName.two, 
            CardName.three, 
            CardName.four,
            CardName.five,
            CardName.six,
            CardName.seven,
            CardName.eight,
            CardName.nine,
            CardName.ten,
            CardName.jack,
            CardName.queen,
            CardName.king,
            CardName.ace
        };

        public static readonly CardSuite[] allsuites = {
            CardSuite.heart,
            CardSuite.diamond,
            CardSuite.club,
            CardSuite.spade            
        };
        private readonly int count = 52;
        public List<Card> stack = new();
        public CardStack() {
            for(int i = 0; i < CardStack.allsuites.Length; ++i)
            {
                for(int j = 0;j < CardStack.allnames.Length; ++j)
                {
                    stack.Add(new Card(allnames[j], allsuites[i]));
                }
            }
        }

        public void Shuffle(int randomness = 200000)
        {      
            Random x = new Random();
            for(int i = 0;i<randomness;++i)
            {
                int first = x.Next(0, 52);
                int second = x.Next(0, 52);
                Card temp = stack[first];
                stack[first] = stack[second];
                stack[second] = temp;
            }
        }

        public Card DealTop()
        {
            Card res = stack[0];
            stack.RemoveAt(0);
            return res;
        }
    }
}
