using System;
using BoardLayer;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Board chessBoard = new Board(new Vector2(15, 20));
            Display.ShowBoard(chessBoard);
        }
    }
}
