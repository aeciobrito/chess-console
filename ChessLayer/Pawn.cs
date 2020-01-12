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

        private bool EnemySpot(Vector2 position)
        {
            Piece piece = Board.SelectPiece(position);
            return piece != null && piece.Color != Color;
        }        

        public override bool[,] MoveOptions()
        {
            bool[,] validMove = new bool[Board.Size.x, Board.Size.y]; //this will repeat, use virutal

            Vector2 position = new Vector2(0, 0);

            if (Color == GameManager.Player1Color) //read the GameManager to know the Player1Color
            {
                position.SetPosition(Position.x - 1, Position.y);
                if (Board.ValidPosition(position) && Board.SelectPiece(position) == null)
                    validMove[position.x, position.y] = true;

                position.SetPosition(Position.x - 2, Position.y);
                if (Board.ValidPosition(position) && Board.SelectPiece(position) == null && MoveCounter == 0)
                    validMove[position.x, position.y] = true;

                position.SetPosition(Position.x - 1, Position.y -1);
                if (Board.ValidPosition(position) && EnemySpot(position))
                    validMove[position.x, position.y] = true;

                position.SetPosition(Position.x - 1, Position.y + 1);
                if (Board.ValidPosition(position) && EnemySpot(position))
                    validMove[position.x, position.y] = true;
            }
            else
            {
                position.SetPosition(Position.x + 1, Position.y);
                if (Board.ValidPosition(position) && Board.SelectPiece(position) == null)
                    validMove[position.x, position.y] = true;

                position.SetPosition(Position.x + 2, Position.y);
                if (Board.ValidPosition(position) && Board.SelectPiece(position) == null && MoveCounter == 0)
                    validMove[position.x, position.y] = true;

                position.SetPosition(Position.x + 1, Position.y - 1);
                if (Board.ValidPosition(position) && EnemySpot(position))
                    validMove[position.x, position.y] = true;

                position.SetPosition(Position.x + 1, Position.y + 1);
                if (Board.ValidPosition(position) && EnemySpot(position))
                    validMove[position.x, position.y] = true;
            }       

            return validMove;
        }
    }
}
