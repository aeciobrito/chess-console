using System;

namespace BoardLayer
{
    class Board
    {
        public Vector2 Size { get; private set; }
        private Piece[,] _tiles;

        public Board(Vector2 size)
        {
            Size = size;
            _tiles = new Piece[size.x, size.y];
        }

        public Piece Piece(int x, int y)
        {
            return _tiles[x, y];
        }

        public Piece Piece(Vector2 position)
        {
            return _tiles[position.x, position.y];
        }

        public bool BusyPlace(Vector2 position)
        {
            ValidPosition(position);
            return Piece(position) != null;
        }

        public void SetPiece(Piece piece, Vector2 position)
        {
            if (BusyPlace(position))
                throw new BoardExeption("There is a piece here already");

            _tiles[position.x, position.y] = piece;
            piece.SetPosition(position);
        }

        public void ValidPosition(Vector2 position)
        {
            if (position.x < 0 || position.x > Size.x || position.y < 0 || position.y > Size.y)
                throw new BoardExeption("Invalid Position");
        }
    }
}
