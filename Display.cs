using System;
using BoardLayer;
using ChessLayer;

namespace ChessConsole
{
    //White{♔♕♖♗♘♙} Black{♚♛♜♝♞♟}
    class Display
    {
        public static void ShowBoard(Board board)
        {
            ResetColors();
            Console.WriteLine("  A B C D E F G H");
            for (int x = 0; x < board.Size.x; x++)
            {
                Console.Write(8 - x + " ");
                for (int y = 0; y < board.Size.y; y++)
                {
                    if (((x + y) % 2 == 0)) //Vitu
                        Console.BackgroundColor = ConsoleColor.White;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    if (board.Piece(x, y) != null)
                    {
                        Console.ForegroundColor = board.Piece(x, y).Color;
                        Console.Write(board.Piece(x, y) + " ");
                    }
                    else
                        Console.Write("  ");
                }
                ResetColors();
                Console.WriteLine(" " + (8 - x));
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ResetColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static ChessPosition ReadPositions()
        {
            string inputText = Console.ReadLine();
            char column = inputText[0];
            int line = int.Parse(inputText[1].ToString());
            return new ChessPosition(column, line);
        }
    }
}
