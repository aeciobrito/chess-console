using System;
using BoardLayer;
using ChessLayer;

namespace ChessConsole
{
    class Program
    {
        static int windowsSizeX = 40, windowsSizeY = 15;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(windowsSizeX, windowsSizeY);
            Console.Title = "Chess";

            Board chessBoard = new Board(new Vector2(8, 8));

            chessBoard.SetPiece(new Rook(ConsoleColor.Red, chessBoard), new Vector2(0, 0));
            chessBoard.SetPiece(new Rook(ConsoleColor.Red, chessBoard), new Vector2(0, 7));
            chessBoard.SetPiece(new King(ConsoleColor.Red, chessBoard), new Vector2(0, 4));
            chessBoard.SetPiece(new Queen(ConsoleColor.Red, chessBoard), new Vector2(0, 3));
            chessBoard.SetPiece(new Bishop(ConsoleColor.Red, chessBoard), new Vector2(0, 2));
            chessBoard.SetPiece(new Bishop(ConsoleColor.Red, chessBoard), new Vector2(0, 5));
            chessBoard.SetPiece(new Knight(ConsoleColor.Red, chessBoard), new Vector2(0, 1));
            chessBoard.SetPiece(new Knight(ConsoleColor.Red, chessBoard), new Vector2(0, 6));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Red, chessBoard), new Vector2(1, 0));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Red, chessBoard), new Vector2(1, 1));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Red, chessBoard), new Vector2(1, 2));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Red, chessBoard), new Vector2(1, 3));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Red, chessBoard), new Vector2(1, 4));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Red, chessBoard), new Vector2(1, 5));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Red, chessBoard), new Vector2(1, 6));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Red, chessBoard), new Vector2(1, 7));

            chessBoard.SetPiece(new Rook(ConsoleColor.Blue, chessBoard), new Vector2(7, 0));
            chessBoard.SetPiece(new Rook(ConsoleColor.Blue, chessBoard), new Vector2(7, 7));
            chessBoard.SetPiece(new King(ConsoleColor.Blue, chessBoard), new Vector2(7, 4));
            chessBoard.SetPiece(new Queen(ConsoleColor.Blue, chessBoard), new Vector2(7, 3));
            chessBoard.SetPiece(new Bishop(ConsoleColor.Blue, chessBoard), new Vector2(7, 2));
            chessBoard.SetPiece(new Bishop(ConsoleColor.Blue, chessBoard), new Vector2(7, 5));
            chessBoard.SetPiece(new Knight(ConsoleColor.Blue, chessBoard), new Vector2(7, 1));
            chessBoard.SetPiece(new Knight(ConsoleColor.Blue, chessBoard), new Vector2(7, 6));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Blue, chessBoard), new Vector2(6, 0));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Blue, chessBoard), new Vector2(6, 1));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Blue, chessBoard), new Vector2(6, 2));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Blue, chessBoard), new Vector2(6, 3));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Blue, chessBoard), new Vector2(6, 4));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Blue, chessBoard), new Vector2(6, 5));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Blue, chessBoard), new Vector2(6, 6));
            chessBoard.SetPiece(new Pawn(ConsoleColor.Blue, chessBoard), new Vector2(6, 7));

            Display.ShowBoard(chessBoard);
        }
    }
}
