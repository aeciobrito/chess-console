using System;

namespace BoardLayer
{
    class Piece
    {
        public Vector2 Position { get; private set; }
        public ConsoleColor Color { get; private set; }        
        public Board Board { get; set; }
        public int MoveCounter { get; private set; }

        public Piece(Vector2 position, ConsoleColor color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            MoveCounter = 0;
        }
    }
}
