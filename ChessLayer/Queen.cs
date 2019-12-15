using System;
using BoardLayer;

namespace ChessLayer
{
    class Queen : Piece
    {
        public Queen(ConsoleColor color, Board board) : base(color, board)
        {
            //Character = "Q";
            Character = "♚";
        }
    }
}
