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
            bool[,] validMove = new bool[Board.Size.x, Board.Size.y]; //this will repeat, use virutal

            Vector2 position = new Vector2(0, 0);

            position.SetPosition(Position.x - 1, Position.y - 2);
            if (Board.ValidPosition(position) && ValidPiece(position))
                validMove[position.x, position.y] = true;

            position.SetPosition(Position.x - 2, Position.y - 1);
            if (Board.ValidPosition(position) && ValidPiece(position))
                validMove[position.x, position.y] = true;

            position.SetPosition(Position.x - 2, Position.y + 1);
            if (Board.ValidPosition(position) && ValidPiece(position))
                validMove[position.x, position.y] = true;

            position.SetPosition(Position.x - 1, Position.y + 2);
            if (Board.ValidPosition(position) && ValidPiece(position))
                validMove[position.x, position.y] = true;

            position.SetPosition(Position.x + 1, Position.y + 2);
            if (Board.ValidPosition(position) && ValidPiece(position))
                validMove[position.x, position.y] = true;

            position.SetPosition(Position.x + 2, Position.y + 1);
            if (Board.ValidPosition(position) && ValidPiece(position))
                validMove[position.x, position.y] = true;

            position.SetPosition(Position.x + 2, Position.y - 1);
            if (Board.ValidPosition(position) && ValidPiece(position))
                validMove[position.x, position.y] = true;

            position.SetPosition(Position.x + 1, Position.y - 2);
            if (Board.ValidPosition(position) && ValidPiece(position))
                validMove[position.x, position.y] = true;

            return validMove;
        }
    }
}
