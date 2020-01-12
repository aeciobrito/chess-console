using System;
using BoardLayer;

namespace ChessLayer
{
    class Queen : Piece
    {
        public Queen(ConsoleColor color, Board board) : base(color, board)
        {
            //Character = "Q";
            Character = "♛";
        }

        public override bool[,] MoveOptions()
        {
            bool[,] validMove = new bool[Board.Size.x, Board.Size.y]; //this will repeat, use virutal

            Vector2 position = new Vector2(0, 0);

            position.SetPosition(Position.x - 1, Position.y);
            while (Board.ValidPosition(position) && ValidPiece(position))
            {
                validMove[position.x, position.y] = true;

                if (Board.SelectPiece(position) != null && Board.SelectPiece(position).Color != Color)
                    break;

                position.x = position.x - 1;
            }

            position.SetPosition(Position.x + 1, Position.y);
            while (Board.ValidPosition(position) && ValidPiece(position))
            {
                validMove[position.x, position.y] = true;

                if (Board.SelectPiece(position) != null && Board.SelectPiece(position).Color != Color)
                    break;

                position.x = position.x + 1;
            }

            position.SetPosition(Position.x, Position.y + 1);
            while (Board.ValidPosition(position) && ValidPiece(position))
            {
                validMove[position.x, position.y] = true;

                if (Board.SelectPiece(position) != null && Board.SelectPiece(position).Color != Color)
                    break;

                position.y = position.y + 1;
            }

            position.SetPosition(Position.x, Position.y - 1);
            while (Board.ValidPosition(position) && ValidPiece(position))
            {
                validMove[position.x, position.y] = true;

                if (Board.SelectPiece(position) != null && Board.SelectPiece(position).Color != Color)
                    break;

                position.y = position.y - 1;
            }

            position.SetPosition(Position.x - 1, Position.y - 1);
            while (Board.ValidPosition(position) && ValidPiece(position))
            {
                validMove[position.x, position.y] = true;
                if (Board.SelectPiece(position) != null && Board.SelectPiece(position).Color != Color)
                    break;

                position.SetPosition(position.x - 1, position.y - 1);
            }

            position.SetPosition(Position.x - 1, Position.y + 1);
            while (Board.ValidPosition(position) && ValidPiece(position))
            {
                validMove[position.x, position.y] = true;
                if (Board.SelectPiece(position) != null && Board.SelectPiece(position).Color != Color)
                    break;

                position.SetPosition(position.x - 1, position.y + 1);
            }

            position.SetPosition(Position.x + 1, Position.y + 1);
            while (Board.ValidPosition(position) && ValidPiece(position))
            {
                validMove[position.x, position.y] = true;
                if (Board.SelectPiece(position) != null && Board.SelectPiece(position).Color != Color)
                    break;

                position.SetPosition(position.x + 1, position.y + 1);
            }

            position.SetPosition(Position.x + 1, Position.y - 1);
            while (Board.ValidPosition(position) && ValidPiece(position))
            {
                validMove[position.x, position.y] = true;
                if (Board.SelectPiece(position) != null && Board.SelectPiece(position).Color != Color)
                    break;

                position.SetPosition(position.x + 1, position.y - 1);
            }

            return validMove;
        }
    }
}
