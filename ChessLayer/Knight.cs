using System;
using BoardLayer;

namespace ChessLayer
{
    class Knight : Piece
    {
        public Knight(ConsoleColor color, Board board) : base(color, board)
        {
            //Character = "H";
            Character = "♞";
        }

        public override bool[,] MoveOptions()
        {
            throw new NotImplementedException();
        }
    }
}
