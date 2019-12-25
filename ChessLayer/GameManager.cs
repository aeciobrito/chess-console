using System;
using System.Collections.Generic;
using BoardLayer;

namespace ChessLayer
{
    class GameManager
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        private ConsoleColor _player1Color, _player2Color;
        public ConsoleColor CurrentPlayer { get; private set; }
        public bool GameOver { get; private set; }
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _piecesTaken;

        public GameManager()
        {
            Board = new Board(new Vector2(8, 8));
            Turn = 1;
            _player1Color = ConsoleColor.Blue;
            _player2Color = ConsoleColor.Red;
            CurrentPlayer = _player1Color;
            _pieces = new HashSet<Piece>();
            _piecesTaken = new HashSet<Piece>();
            SetPieceOnPlace();
        }

        public void ChangePosition(Vector2 selectedTile, Vector2 destinationTile)
        {
            Piece piece = Board.RemovePiece(selectedTile);
            piece.MoveIncrease();

            Piece removedPiece = Board.RemovePiece(destinationTile);
            if (removedPiece != null)
                _piecesTaken.Add(removedPiece);

            Board.SetPiece(piece, destinationTile);
        }

        public void PlayerMove(Vector2 startPoint, Vector2 endPoint)
        {
            ChangePosition(startPoint, endPoint);
            Turn++;
            ChangePlayer();
        }

        public void SelectedPieceRestrictions(Vector2 position)
        {
            if(Board.SelectPiece(position) == null)
                throw new BoardExeption("There is no piece in this position!");

            if (CurrentPlayer != Board.SelectPiece(position).Color)
                throw new BoardExeption("That is the opponent piece!");

            if (!Board.SelectPiece(position).FreeTiles())
                throw new BoardExeption("There is no move to this piece!");
        }

        public void DestinationPieceRestrictions(Vector2 selectedTile, Vector2 destinationTile)
        {
            if (!Board.SelectPiece(selectedTile).CanMoveTo(destinationTile))
                throw new BoardExeption("Invalid destination!");
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == _player1Color)
                CurrentPlayer = _player2Color;
            else
                CurrentPlayer = _player1Color;
        }

        private void SetPiece(Piece piece, char column, int line)
        {
            Board.SetPiece(piece, new ChessPosition(column, line).ToVector2());
            _pieces.Add(piece);
        }

        public HashSet<Piece> TakenPieces(ConsoleColor color)
        {
            HashSet<Piece> takenPieces = new HashSet<Piece>();

            foreach (Piece piece in _piecesTaken)
                if (piece.Color == color)
                    takenPieces.Add(piece);

            return takenPieces;
        }

        public HashSet<Piece> OnBoardPieces(ConsoleColor color)
        {
            HashSet<Piece> onBoardPieces = new HashSet<Piece>();

            foreach (Piece piece in onBoardPieces)
                if (piece.Color == color)
                    onBoardPieces.Add(piece);

            onBoardPieces.ExceptWith(TakenPieces(color));
            return onBoardPieces;
        }

        private void SetPieceOnPlace()
        {
            SetPiece(new Rook(_player1Color, Board), 'a', 1);            
            SetPiece(new Rook(_player1Color, Board), 'h', 1);
            SetPiece(new Knight(_player1Color, Board), 'b', 1);
            SetPiece(new Knight(_player1Color, Board), 'g', 1);
            SetPiece(new Bishop(_player1Color, Board), 'c', 1);
            SetPiece(new Bishop(_player1Color, Board), 'f', 1);
            SetPiece(new Queen(_player1Color, Board), 'd', 1);
            SetPiece(new King(_player1Color, Board), 'e', 1);
            SetPiece(new Pawn(_player1Color, Board), 'a', 2);
            SetPiece(new Pawn(_player1Color, Board), 'b', 2);
            SetPiece(new Pawn(_player1Color, Board), 'c', 2);
            SetPiece(new Pawn(_player1Color, Board), 'd', 2);
            SetPiece(new Pawn(_player1Color, Board), 'e', 2);
            SetPiece(new Pawn(_player1Color, Board), 'f', 2);
            SetPiece(new Pawn(_player1Color, Board), 'g', 2);
            SetPiece(new Pawn(_player1Color, Board), 'h', 2);

            SetPiece(new Rook(_player2Color, Board), 'a', 8);
            SetPiece(new Rook(_player2Color, Board), 'h', 8);
            SetPiece(new Knight(_player2Color, Board), 'b', 8);
            SetPiece(new Knight(_player2Color, Board), 'g', 8);
            SetPiece(new Bishop(_player2Color, Board), 'c', 8);
            SetPiece(new Bishop(_player2Color, Board), 'f', 8);
            SetPiece(new Queen(_player2Color, Board), 'd', 8);
            SetPiece(new King(_player2Color, Board), 'e', 8);
            SetPiece(new Pawn(_player2Color, Board), 'a', 7);
            SetPiece(new Pawn(_player2Color, Board), 'b', 7);
            SetPiece(new Pawn(_player2Color, Board), 'c', 7);
            SetPiece(new Pawn(_player2Color, Board), 'd', 7);
            SetPiece(new Pawn(_player2Color, Board), 'e', 7);
            SetPiece(new Pawn(_player2Color, Board), 'f', 7);
            SetPiece(new Pawn(_player2Color, Board), 'g', 7);
            SetPiece(new Pawn(_player2Color, Board), 'h', 7);
        }
    }
}

