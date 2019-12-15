using System;

namespace BoardLayer
{
    class Piece
    {
        public Vector2 Position { get; private set; }
        public ConsoleColor Color { get; private set; }        
        public Board Board { get; set; }
        public int MoveCounter { get; private set; }
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
    }
}
