using System;
using BoardLayer;

namespace ChessLayer
{
    class Pawn : Piece
    {
        public Pawn(ConsoleColor color, Board board) : base(color, board)
        {
            //Character = "P";
            Character = "♟";
        }
    }
}
