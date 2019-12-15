using System;
using BoardLayer;

namespace ChessLayer
{
    class Rook : Piece
    {
        public Rook(ConsoleColor color, Board board) : base(color, board)
        {
            Character = "♜";
        }
    }
}
