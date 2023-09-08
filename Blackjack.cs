using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CountingCardGame
{

    internal static partial class Blackjack
    {
        const int maxPoint = 21;       
        public enum GameResult
        {
            win, lose, tie, unknown
        }
    }
}
