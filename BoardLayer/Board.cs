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

        public Piece SelectPiece(int x, int y)
        {
            //move check valid position to here
            return _tiles[x, y];
        }

        public Piece SelectPiece(Vector2 position)
        {
            //move check valid position to here
            return _tiles[position.x, position.y];
        }

        public bool BusyPlace(Vector2 position)
        {
            CheckPosition(position);
            return SelectPiece(position) != null;
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
            if (SelectPiece(position) == null)
            {
                return null;
            }

            Piece piece = SelectPiece(position);
            piece.SetPosition(null);
            _tiles[position.x, position.y] = null;
            return piece;
        }

        public bool ValidPosition(Vector2 position)
        {
            if (position.x < 0 || position.x >= Size.x || position.y < 0 || position.y >= Size.y)
                return false;

            return true;
        }

        public void CheckPosition(Vector2 position)
        {
            if(!ValidPosition(position))
                throw new BoardExeption("Invalid Position");
        }
    }
}
