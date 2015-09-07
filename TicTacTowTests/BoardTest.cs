using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacTow;

namespace TicTacTowTests
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void AImoveTest()
        {
            Board board = new Board();
            board.makeMove(1, 'X');
            board.makeMove(2, 'X');
            board.AImove();
            Assert.AreEqual(board.board[0, 2], 'O');
            board.makeMove(6, 'O');
            board.AImove();
            Assert.AreEqual(board.board[2, 2], 'O');
        }

        [TestMethod]
        public void getBoardCoppyTest()
        {
            Board board1 = new Board();
            board1.makeMove(1, 'X');
            board1.makeMove(6, 'X');
            Board board2 = board1.getBoardCoppy();
            CollectionAssert.AreEqual(board1.board, board2.board);
        }

        [TestMethod]
        public void makeMoveTest()
        {
            Board board = new Board();
            board.makeMove(5, 'X');
            Assert.AreEqual(board.board[1, 1], 'X');
        }

        [TestMethod]
        public void CheckHorizontalWinTest()
        {
            Board board = new Board();
            board.makeMove(4, 'X');
            board.makeMove(5, 'X');
            board.makeMove(6, 'X');
            Assert.AreEqual(board.CheckWin(), 1);
        }

        [TestMethod]
        public void CheckVirticalWinTest()
        {
            Board board = new Board();
            board.makeMove(2, 'X');
            board.makeMove(5, 'X');
            board.makeMove(8, 'X');
            Assert.AreEqual(board.CheckWin(), 1);
        }

        [TestMethod]
        public void CheckDiagnalWinTest()
        {
            Board board = new Board();
            board.makeMove(1, 'X');
            board.makeMove(5, 'X');
            board.makeMove(9, 'X');
            Assert.AreEqual(board.CheckWin(), 1);
        }

        [TestMethod]
        public void CheckDrawTest()
        {
            Board board = new Board();
            board.makeMove(1, 'X');
            board.makeMove(2, 'X');
            board.makeMove(3, 'O');
            board.makeMove(4, 'O');
            board.makeMove(5, 'O');
            board.makeMove(6, 'X');
            board.makeMove(7, 'X');
            board.makeMove(8, 'O');
            board.makeMove(9, 'X');
            Assert.AreEqual(board.CheckWin(), -1);
        }

        [TestMethod]
        public void CheckStillinPlayTest()
        {
            Board board = new Board();
            board.makeMove(1, 'X');
            board.makeMove(2, 'X');
            board.makeMove(3, 'O');
            board.makeMove(4, 'O');
            board.makeMove(5, 'O');
            board.makeMove(6, 'X');
            board.makeMove(7, 'X');
            board.makeMove(8, 'O');
            Assert.AreEqual(board.CheckWin(), 0);
        }

    }
}
