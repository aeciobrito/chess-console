using System;
using BoardLayer;

namespace ChessLayer
{
    class King : Piece
    {
        public King(ConsoleColor color, Board board) : base(color, board)
        {
            //Character = "K";
            Character = "♚";
        }

        public override bool[,] MoveOptions()  //maybe virtual
        {
            bool[,] validMove = new bool[Board.Size.x, Board.Size.y]; //this will repeat, use virutal

            Vector2 position = new Vector2(0, 0);

            position.SetPosition(Position.x - 1, Position.y);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                validMove[position.x, position.y] = true;
            }

            position.SetPosition(Position.x - 1, Position.y + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                validMove[position.x, position.y] = true;
            }

            position.SetPosition(Position.x - 1, Position.y - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                validMove[position.x, position.y] = true;
            }

            position.SetPosition(Position.x, Position.y - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                validMove[position.x, position.y] = true;
            }

            position.SetPosition(Position.x, Position.y + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                validMove[position.x, position.y] = true;
            }

            position.SetPosition(Position.x + 1, Position.y);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                validMove[position.x, position.y] = true;
            }

            position.SetPosition(Position.x + 1, Position.y + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                validMove[position.x, position.y] = true;
            }

            position.SetPosition(Position.x + 1, Position.y - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                validMove[position.x, position.y] = true;
            }

            return validMove;
        }
    }
}
