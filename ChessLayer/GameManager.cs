using System;
using BoardLayer;

namespace ChessLayer
{
    class GameManager
    {
        public Board Board { get; private set; }
        private int _turn;
        private ConsoleColor _playerColor;

        public GameManager()
        {
            Board = new Board(new Vector2(8, 8));
            _turn = 1;
            _playerColor = ConsoleColor.Blue;
            SetPieces();
        }

        public void Move(Vector2 startPoint, Vector2 endPoint)
        {
            //IF PIECE != NULL??
            Piece piece = Board.RemovePiece(startPoint);
            piece.MoveIncrease();
            Piece removedPiece = Board.RemovePiece(endPoint);
            Board.PutPiece(piece, endPoint);
        }

        private void SetPieces()
        {
            Board.PutPiece(new Rook(ConsoleColor.Blue, Board), new ChessPosition('a', 1).ToVector2());
            Board.PutPiece(new Rook(ConsoleColor.Blue, Board), new ChessPosition('h', 1).ToVector2());
            Board.PutPiece(new Knight(ConsoleColor.Blue, Board), new ChessPosition('b', 1).ToVector2());
            Board.PutPiece(new Knight(ConsoleColor.Blue, Board), new ChessPosition('g', 1).ToVector2());
            Board.PutPiece(new Bishop(ConsoleColor.Blue, Board), new ChessPosition('c', 1).ToVector2());
            Board.PutPiece(new Bishop(ConsoleColor.Blue, Board), new ChessPosition('f', 1).ToVector2());
            Board.PutPiece(new Queen(ConsoleColor.Blue, Board), new ChessPosition('d', 1).ToVector2());
            Board.PutPiece(new King(ConsoleColor.Blue, Board), new ChessPosition('e', 1).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Blue, Board), new ChessPosition('a', 2).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Blue, Board), new ChessPosition('b', 2).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Blue, Board), new ChessPosition('c', 2).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Blue, Board), new ChessPosition('d', 2).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Blue, Board), new ChessPosition('e', 2).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Blue, Board), new ChessPosition('f', 2).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Blue, Board), new ChessPosition('g', 2).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Blue, Board), new ChessPosition('h', 2).ToVector2());

            Board.PutPiece(new Rook(ConsoleColor.Red, Board), new ChessPosition('a', 8).ToVector2());
            Board.PutPiece(new Rook(ConsoleColor.Red, Board), new ChessPosition('h', 8).ToVector2());
            Board.PutPiece(new Knight(ConsoleColor.Red, Board), new ChessPosition('b', 8).ToVector2());
            Board.PutPiece(new Knight(ConsoleColor.Red, Board), new ChessPosition('g', 8).ToVector2());
            Board.PutPiece(new Bishop(ConsoleColor.Red, Board), new ChessPosition('c', 8).ToVector2());
            Board.PutPiece(new Bishop(ConsoleColor.Red, Board), new ChessPosition('f', 8).ToVector2());
            Board.PutPiece(new Queen(ConsoleColor.Red, Board), new ChessPosition('d', 8).ToVector2());
            Board.PutPiece(new King(ConsoleColor.Red, Board), new ChessPosition('e', 8).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Red, Board), new ChessPosition('a', 7).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Red, Board), new ChessPosition('b', 7).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Red, Board), new ChessPosition('c', 7).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Red, Board), new ChessPosition('d', 7).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Red, Board), new ChessPosition('e', 7).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Red, Board), new ChessPosition('f', 7).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Red, Board), new ChessPosition('g', 7).ToVector2());
            //Board.PutPiece(new Pawn(ConsoleColor.Red, Board), new ChessPosition('h', 7).ToVector2());
        }
    }
}

