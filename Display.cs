using System;
using BoardLayer;

namespace ChessConsole
{
    class Display
    {
        public static void ShowBoard(Board board)
        {
            for (int x = 0; x < board.Size.x; x++)
            {
                for (int y = 0; y < board.Size.y; y++)
                {
                    //if (board.Piece(x, y) == null && (x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0))
                    if (board.Piece(x, y) == null && ((x + y) % 2 == 0)) //Vitu
                    {
                        Console.Write("■ ");
                    }
                    else if (board.Piece(x, y) == null)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(board.Piece(x, y) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
