using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTow
{
    public class Program
    {

        static void Main(string[] args)
        {
            dispayMenue();
            ConsoleKeyInfo choice = getChoice();
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                    PvC();
                    break;
                case ConsoleKey.D2:
                    PvP();
                    break;
                default:
                    Console.WriteLine("\n \n Good bye");
                    break;
            }
            Console.ReadLine();
        }

        static void PvP()
        {
            bool player = false;
            Board board = new Board();
            int gameState = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                if (player)
                {
                    Console.WriteLine("Player 2 move");
                }
                else
                {
                    Console.WriteLine("Player 1 move");
                }
                Console.WriteLine("\n");
                board.displayBoard();
                int choice = getMove(board);
                if (player)
                {
                    board.makeMove(choice, 'O');
                }
                else
                {
                    board.makeMove(choice, 'X');
                }
                player = !player;
                gameState = board.CheckWin();
            } while (gameState == 0);

            Console.Clear();
            Console.WriteLine("\n");
            board.displayBoard();

            if (gameState == 1)
            {
                Console.WriteLine("Player {0} has won", (player) ? "2" : "1");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }

        static void PvC()
        {
            bool player = false;
            Board board = new Board();
            int gameState = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Player:X and Computer:O");
                Console.WriteLine("\n");
                if (player)
                {
                    board.AImove();
                }
                else
                {
                    Console.WriteLine("Your turn");
                    Console.WriteLine("\n");
                    board.displayBoard();
                    int choice = getMove(board);
                    board.makeMove(choice, 'X');
                }
                player = !player;
                gameState = board.CheckWin();
            } while (gameState == 0);

            Console.Clear();
            Console.WriteLine("\n");
            board.displayBoard();

            if (gameState == 1)
            {
                if (player)
                    Console.WriteLine("Player has won");
                else
                    Console.WriteLine("Computer has won");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }

        static int getMove(Board board)
        {
            Console.Write("\n input: ");
            ConsoleKeyInfo cki = Console.ReadKey();
            while (!board.availabeMoves.Contains(cki.KeyChar))
            {
                Console.WriteLine("\n that was an invalid choice please try again");
                Console.Write("\n input: ");
                cki = Console.ReadKey();
            }
            board.availabeMoves.Remove(cki.KeyChar);
            return int.Parse(cki.KeyChar.ToString());
        }

        static ConsoleKeyInfo getChoice()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            while (cki.Key != ConsoleKey.D1 && cki.Key != ConsoleKey.D2 && cki.Key != ConsoleKey.X)
            {
                Console.WriteLine("\n the options are 1, 2, or x try again");
                Console.Write("\n input: ");
                cki = Console.ReadKey();
            }
            return cki;
        }
        static void dispayMenue()
        {
            Console.WriteLine("     Tic Tac Tow \n");
            Console.WriteLine("Please choose game type");
            Console.WriteLine("1. Player vs Computer");
            Console.WriteLine("2. Player vs Player");
            Console.WriteLine("press x to exit");
            Console.Write("\n input: ");
        }
    }
}
