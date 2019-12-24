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

        protected bool CanMove(Vector2 position)
        {
            Piece piece = Board.SelectPiece(position);
            return piece == null || piece.Color != Color;
        }

        public abstract bool[,] MoveOptions();
    }
}
