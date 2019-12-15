using System;
using BoardLayer;

namespace ChessLayer
{
    class Bishop : Piece
    {
        public Bishop(ConsoleColor color, Board board) : base(color, board)
        {
            //Character = "B";
            Console.ForegroundColor = ConsoleColor.Red;
            Character = "♝";
        }
    }
}
