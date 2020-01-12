using System;

namespace BoardLayer
{
    abstract class Piece
    {
        public Vector2 Position { get; protected set; }
        public ConsoleColor Color { get; protected set; }        
        public Board Board { get; protected set; }
        public int MoveCounter { get; protected set; }
        public string Character { get; protected set; }

        public Piece(ConsoleColor color, Board board)
        {
            Color = color;
            Board = board;
            MoveCounter = 0;
        }

        public override string ToString()
        {
            return Character;
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public void MoveIncrease()
        {
            MoveCounter++;
        }
        
        public void MoveDecrease()
        {
            MoveCounter--;
        }

        protected bool ValidPiece(Vector2 position)
        {
            Piece piece = Board.SelectPiece(position);
            return piece == null || piece.Color != Color;
        }

        public abstract bool[,] MoveOptions();

        public bool FreeTiles()
        {
            bool[,] tiles = MoveOptions();

            for (int i = 0; i < Board.Size.x; i++)
            {
                for (int j = 0; j < Board.Size.y; j++)
                {
                    if (tiles[i, j])
                        return true;
                }
            }
            return false;
        }

        public bool CanMoveTo(Vector2 position)
        {
            return MoveOptions()[position.x, position.y];
        }
    }
}
