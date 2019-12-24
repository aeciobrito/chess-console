using System;
using BoardLayer;

namespace ChessLayer
{
    class Bishop : Piece
    {
        public Bishop(ConsoleColor color, Board board) : base(color, board)
        {
            //Character = "B";
            Character = "♝";
        }

        public override bool[,] MoveOptions()
        {
            throw new NotImplementedException();
        }
    }
}
