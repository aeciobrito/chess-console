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
            _tiles = new Piece[Size.x, Size.y];
        }
        
        public Board(int lines, int columns)
        {
            Size.x = lines;
            Size.y = columns;
            _tiles = new Piece[Size.x, Size.y];
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

        public void PutPiece(Piece piece, Vector2 position)
        {
            if (BusyPlace(position))
                throw new BoardExeption("There is a piece here already");

            _tiles[position.x, position.y] = piece;
            piece.SetPosition(position);
        }

        public Piece RemovePiece(Vector2 position)
        {
            if (Piece(position) == null)
            {
                return null;
            }

            Piece piece = Piece(position);
            piece.SetPosition(null);
            _tiles[position.x, position.y] = null;
            return piece;
        }

        public void ValidPosition(Vector2 position)
        {
            if (position.x < 0 || position.x > Size.x || position.y < 0 || position.y > Size.y)
                throw new BoardExeption("Invalid Position");
        }
    }
}
