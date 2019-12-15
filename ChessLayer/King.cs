using System;
using BoardLayer;

namespace ChessLayer
{
    class King : Piece
    {
        public King(ConsoleColor color, Board board) : base(color, board)
        {
            //Character = "K";
            Character = "♛";
        }
    }
}
