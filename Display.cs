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
                    if (((x + y) % 2 == 0)) //Vitu
                        Console.BackgroundColor = ConsoleColor.White;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    if(board.Piece(x, y) != null)
                        Console.Write(board.Piece(x, y) + " ");
                    else
                        Console.Write("  ");                    
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
    }
}
