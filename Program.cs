using System.ComponentModel;
using System.Xml.Linq;

namespace CountingCardGame
{
    class Program
    {

        const int dealerMinScore = 17;
        static CardStack stack = new();
        static Blackjack.Player player = new();
        static Blackjack.Player dealer = new();

        static void playerDeal()
        {
            Card card = stack.DealTop();
            player.Deal(card);
            Console.WriteLine($"You are dealt the {card.Name} of {card.Suite}!");
            PlayerShowHand();
        }
        static void PlayerTurn()
        {
            bool cont = true;
            while (cont)
            {
                PlayerShowHand();
                if (player.Busted())
                {
                    Console.WriteLine("You busted!");
                    cont = false;
                    continue;
                }
                Console.WriteLine("Hit or Stand ? (h\\s)..");
                string ans = Console.ReadLine();
                if (ans.Equals("h"))
                {
                    playerDeal();
                }
                else if (ans.Equals("s"))
                {
                    Console.WriteLine("You stand!");
                    cont = false;
                }
                else
                {
                    Console.WriteLine("Unknown choice? Retry");
                }
            }
        }

        static void DealerDeal()
        {
            dealer.Deal(stack.DealTop());
            Console.WriteLine("Dealer dealt himself a card.");
        }
        static void DealerTurn()
        {
            while (dealer.Score() < dealerMinScore)
            {
                DealerDeal();
            }
        }

        static void DealerShowHand()
        {
            if(dealer.Natural())
            {
                Console.WriteLine("Dealer got a natural!");
            }
            Console.WriteLine($"Dealer's hand : {dealer.AllCards()}");
            if (dealer.Natural())
            {
                Console.WriteLine("Dealer got a natural!");
            } else
                Console.WriteLine($"Dealer has {dealer.Score()} points!");
        }
        static void PlayerShowHand()
        {
            Console.WriteLine($"Current hand : {player.AllCards()}");
            if (player.Natural())
            {
                Console.WriteLine("You got a natural!");
            }
            else
                Console.WriteLine($"Your current score is {player.Score()}!");
        }

        static Blackjack.GameResult DetermineGameResult(Blackjack.Player player, Blackjack.Player dealer)
        {
            var result = Blackjack.GameResult.unknown;
            if (player.Busted())
            {
                if (dealer.Busted())
                {
                    result = Blackjack.GameResult.tie;
                }
                else
                    result = Blackjack.GameResult.lose;
            }
            else if (player.Natural())
            {
                if (dealer.Natural())
                {
                    result = Blackjack.GameResult.tie;
                }
                else
                    result = Blackjack.GameResult.win;
            }
            else
            {
                if (dealer.Natural())
                {
                    result = Blackjack.GameResult.lose;
                }
                else if (dealer.Busted())
                {
                    result = Blackjack.GameResult.win;
                }
                else
                {
                    if (dealer.Score() == player.Score())
                        result = Blackjack.GameResult.tie;
                    else if (dealer.Score() > player.Score())
                        result = Blackjack.GameResult.lose;
                    else
                        result = Blackjack.GameResult.win;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            bool another = false;
            do
            {
                Blackjack.GameResult result = Blackjack.GameResult.unknown;
                Console.WriteLine("BLACKJACK!");
                stack = new();
                player = new();
                dealer = new();
                stack.Shuffle();
                playerDeal();
                DealerDeal();
                playerDeal();
                DealerDeal();

                if (!player.Natural() && !dealer.Natural())
                {
                    PlayerTurn();
                    DealerTurn();
                }
                result = DetermineGameResult(player, dealer);
                string msg;
                switch (result)
                {
                    case Blackjack.GameResult.win:
                        msg = "YOU WIN!!!";
                        break;
                    case Blackjack.GameResult.lose:
                        msg = "You lose...";
                        break;
                    case Blackjack.GameResult.tie:
                        msg = "It's a tie!";
                        break;
                    case Blackjack.GameResult.unknown:
                    default:
                        msg = "Unknown";
                        break;
                }
                PlayerShowHand();
                DealerShowHand();
                Console.WriteLine(msg);
                Console.Write("Type 'y' for another round..");
                another = Console.ReadLine().Equals("y");
            } while (another);
            Console.WriteLine("Bye-");
        }
    }
}