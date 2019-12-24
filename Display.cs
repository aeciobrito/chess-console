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
                    DrawBoard(x, y);
                    DrawPieces(x, y, board);
                }
                ResetColors();
                Console.WriteLine(" " + (8 - x));
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static void ShowBoard(Board board, bool[,] moveOptions)
        {
            ResetColors();
            Console.WriteLine("  A B C D E F G H");
            for (int x = 0; x < board.Size.x; x++)
            {
                Console.Write(8 - x + " ");
                for (int y = 0; y < board.Size.y; y++)
                {
                    DrawBoard(x, y);
                    DrawPieces(x, y, board, moveOptions);
                }
                ResetColors();
                Console.WriteLine(" " + (8 - x));
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void DrawBoard(int x, int y)
        {
            if (((x + y) % 2 == 0))
                Console.BackgroundColor = ConsoleColor.White;
            else
                Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void DrawPieces(int x, int y, Board board)
        {
            if (board.SelectPiece(x, y) != null)
            {
                Console.ForegroundColor = board.SelectPiece(x, y).Color;
                Console.Write(board.SelectPiece(x, y) + " ");
            }
            else
                Console.Write("  ");
        }
        public static void DrawPieces(int x, int y, Board board, bool[,] moveOptions)
        {
            if (board.SelectPiece(x, y) != null)
            {
                Console.ForegroundColor = board.SelectPiece(x, y).Color;
                Console.Write(board.SelectPiece(x, y) + " ");
            }
            else if (moveOptions[x, y])
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("■");
            }
            else
                 Console.Write("  ");
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
