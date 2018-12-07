using System;
using Manatee.Trello;
using System.Threading.Tasks;

namespace TrelloCards
{
    class Program
    {
        static void Main(string[] args)
        {

            TrelloAuthorization.Default.AppKey = "";
            TrelloAuthorization.Default.UserToken = "";

            retrieveBoardCards().GetAwaiter().GetResult();


            async Task retrieveBoardCards()
            {
                try
                {
                    var board = new Board("4d5ea62fd76aa1136000000c");
                    await board.Refresh();
                    Console.WriteLine($"All card of {board.Name}:");
                    var cards = board.Cards;
                    await cards.Refresh();
                    foreach (Card card in cards)
                        Console.WriteLine("· " + card.Name);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Something was wrong " + e.Message);
                }
            }
        }
    }
}
