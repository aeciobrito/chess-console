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
            bool[,] validMoves = new bool[Board.Size.x, Board.Size.y]; //this will repeat, use virutal

            Vector2 position = new Vector2(0, 0);

            position.SetPosition(Position.x - 1, Position.y - 1);
            while (Board.ValidPosition(position) && ValidPiece(position))
            {
                validMoves[position.x, position.y] = true;
                if (Board.SelectPiece(position) != null && Board.SelectPiece(position).Color != Color)
                    break;

                position.SetPosition(position.x - 1, position.y - 1);
            }

            position.SetPosition(Position.x - 1, Position.y + 1);
            while (Board.ValidPosition(position) && ValidPiece(position))
            {
                validMoves[position.x, position.y] = true;
                if (Board.SelectPiece(position) != null && Board.SelectPiece(position).Color != Color)
                    break;

                position.SetPosition(position.x - 1, position.y + 1);
            }

            position.SetPosition(Position.x + 1, Position.y + 1);
            while (Board.ValidPosition(position) && ValidPiece(position))
            {
                validMoves[position.x, position.y] = true;
                if (Board.SelectPiece(position) != null && Board.SelectPiece(position).Color != Color)
                    break;

                position.SetPosition(position.x + 1, position.y + 1);
            }

            position.SetPosition(Position.x + 1, Position.y - 1);
            while (Board.ValidPosition(position) && ValidPiece(position))
            {
                validMoves[position.x, position.y] = true;
                if (Board.SelectPiece(position) != null && Board.SelectPiece(position).Color != Color)
                    break;

                position.SetPosition(position.x + 1, position.y - 1);
            }

            return validMoves;
        }
    }
}
