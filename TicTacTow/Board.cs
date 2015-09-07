using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTow
{
    public class Board
    {
        public char[,] board = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        public List<char> availabeMoves = new List<char>(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' });

        public void AImove()
        {
            Board tempBoard;
            foreach(char c in availabeMoves)
            {
                tempBoard = this.getBoardCoppy();
                tempBoard.makeMove(int.Parse(c.ToString()), 'O');
                if (tempBoard.CheckWin() == 1)
                {
                    this.makeMove(int.Parse(c.ToString()), 'O');
                    availabeMoves.Remove(c);
                    return;
                }
            }
            foreach (char c in availabeMoves)
            {
                tempBoard = this.getBoardCoppy();
                tempBoard.makeMove(int.Parse(c.ToString()), 'X');
                if (tempBoard.CheckWin() == 1)
                {
                    this.makeMove(int.Parse(c.ToString()), 'O');
                    availabeMoves.Remove(c);
                    return;
                }
            }
            Random rnd = new Random();
            int r = rnd.Next(availabeMoves.Count);
            this.makeMove(int.Parse(availabeMoves[r].ToString()), 'O');
            availabeMoves.Remove(availabeMoves[r]);
        }

        public Board getBoardCoppy()
        {
            Board tempBoard = new Board();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tempBoard.makeMove((i * 3) + (j + 1), board[i, j]);
                }
            }
            return tempBoard;
        }

        public void makeMove(int place, char player)
        {
            place--;
            int row = place / 3;
            int column = place % 3;
            board[row, column] = player;
        }

        public void displayBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("     |     |      ");
        }

        public int CheckWin()
        {
            int i;
            // Check across 
            for (i = 0; i < 3; i++)
                if (board[i, 0] == board[i, 1] && board[i, 2] == board[i, 1])
                {
                    return 1;
                }
            // Check down
            for (i = 0; i < 3; i++)
                if (board[0, i] == board[1, i] && board[2, i] == board[1, i])
                {
                    return 1;
                }
            // check diagonals
            if (board[0, 0] == board[1, 1] && board[2, 2] == board[1, 1])
                return 1;
            if (board[0, 2] == board[1, 1] && board[2, 0] == board[1, 1])
                return 1;

            // If all the cells or values filled with X or O then any player has won the match  
            if (board[0, 0] != '1' && board[0, 1] != '2' && board[0, 2] != '3' && board[1, 0] != '4' && board[1, 1] != '5' && board[1, 2] != '6' && board[2, 0] != '7' && board[2, 1] != '8' && board[2, 2] != '9')
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }
    }
}
