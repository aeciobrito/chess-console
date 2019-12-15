﻿using System;

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
    }
}
