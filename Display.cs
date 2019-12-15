using System;
using BoardLayer;

namespace ChessConsole
{
    //White{♔♕♖♗♘♙} Black{♚♛♜♝♞♟}
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
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("  ");
                    }
                    else if (board.Piece(x, y) == null)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                    }
                    else if(((x + y) % 2 == 0))
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(board.Piece(x, y) +" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(board.Piece(x, y) + " ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
    }
}
