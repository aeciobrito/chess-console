using System;
using System.Collections.Generic;
using BoardLayer;

namespace ChessLayer
{
    class GameManager
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public static ConsoleColor Player1Color { get; set; }
        public static ConsoleColor Player2Color {get; set;}
        public ConsoleColor CurrentPlayer { get; private set; }
        public bool GameOver { get; private set; }
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _piecesTaken;
        public bool Check { get; private set; }

        public GameManager()
        {
            Board = new Board(new Vector2(8, 8));
            Turn = 1;
            Player1Color = ConsoleColor.Blue;
            Player2Color = ConsoleColor.Red;
            CurrentPlayer = Player1Color;
            _pieces = new HashSet<Piece>();
            _piecesTaken = new HashSet<Piece>();
            SetPieceOnPlace();
        }

        public Piece ChangePosition(Vector2 selectedTile, Vector2 destinationTile)
        {
            Piece piece = Board.RemovePiece(selectedTile);
            piece.MoveIncrease();

            Piece removedPiece = Board.RemovePiece(destinationTile);
            if (removedPiece != null)
                _piecesTaken.Add(removedPiece);
            
            Board.SetPiece(piece, destinationTile);

            return removedPiece;
        }

        public void PlayerMove(Vector2 startPoint, Vector2 endPoint)
        {
            Piece pieceTaken = ChangePosition(startPoint, endPoint);

            if (OnCheck(CurrentPlayer))
            {
                UndoMove(startPoint, endPoint, pieceTaken); //
                throw new BoardExeption("Can't put yourself in check!");
            }

            if (OnCheck(Opponent(CurrentPlayer)))
                Check = true;
            else
                Check = false;

            if (OnCheckMate(Opponent(CurrentPlayer)))
            {
                GameOver = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
        }

        void UndoMove(Vector2 selectedTile, Vector2 destinationTile, Piece takenPiece)
        {
            Piece piece = Board.RemovePiece(destinationTile);
            piece.MoveDecrease();

            if (destinationTile != null)
            {
                Board.SetPiece(takenPiece, destinationTile);
                _piecesTaken.Remove(takenPiece);
            }
            Board.SetPiece(piece, selectedTile);
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
            if (CurrentPlayer == Player1Color)
                CurrentPlayer = Player2Color;
            else
                CurrentPlayer = Player1Color;
        }

        private ConsoleColor Opponent(ConsoleColor color)
        {
            if (color == ConsoleColor.Red)
                return ConsoleColor.Blue;

            return ConsoleColor.Red;
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

        private Piece IsAKing(ConsoleColor color)
        {
            foreach (Piece piece in OnBoardPieces(color))
                if (piece is King)
                    return piece;

            return null;
        }

        public bool OnCheck(ConsoleColor color)
        {
            Piece king = IsAKing(color);

            foreach (Piece piece in OnBoardPieces(Opponent(color)))  //opponent?
            {
                bool[,] allMoves = piece.MoveOptions();
                if (allMoves[king.Position.x, king.Position.y])
                    return true;
            }
            return false;
        }

        public bool OnCheckMate(ConsoleColor color)
        {
            if (!OnCheck(color))
                return false;
            
            foreach(Piece piece in OnBoardPieces(color))
            {
                bool[,] pieceMoves = piece.MoveOptions();

                for (int x = 0; x < Board.Size.x; x++)
                {
                    for (int y = 0; y < Board.Size.y; y++)
                    {
                        if (pieceMoves[x,y])
                        {
                            Vector2 originalPosition = piece.Position;
                            Vector2 modifiedPosition = new Vector2(x, y);

                            Piece movedPiece = ChangePosition(originalPosition, modifiedPosition);

                            bool onCheck = OnCheck(color);
                            UndoMove(originalPosition, modifiedPosition, movedPiece);
                            if (onCheck)
                                return false;
                        }
                    }
                }
            }
            return true;
        }       

        private void SetPieceOnPlace()
        {
            SetPiece(new Rook(Player1Color, Board), 'a', 1);            
            SetPiece(new Rook(Player1Color, Board), 'h', 1);
            SetPiece(new Knight(Player1Color, Board), 'b', 1);
            SetPiece(new Knight(Player1Color, Board), 'g', 1);
            SetPiece(new Bishop(Player1Color, Board), 'c', 1);
            SetPiece(new Bishop(Player1Color, Board), 'f', 1);
            SetPiece(new Queen(Player1Color, Board), 'd', 1);
            SetPiece(new King(Player1Color, Board), 'e', 1);
            SetPiece(new Pawn(Player1Color, Board), 'a', 2);
            SetPiece(new Pawn(Player1Color, Board), 'b', 2);
            SetPiece(new Pawn(Player1Color, Board), 'c', 2);
            SetPiece(new Pawn(Player1Color, Board), 'd', 2);
            SetPiece(new Pawn(Player1Color, Board), 'e', 2);
            SetPiece(new Pawn(Player1Color, Board), 'f', 2);
            SetPiece(new Pawn(Player1Color, Board), 'g', 2);
            SetPiece(new Pawn(Player1Color, Board), 'h', 2);

            SetPiece(new Rook(Player2Color, Board), 'a', 8);
            SetPiece(new Rook(Player2Color, Board), 'h', 8);
            SetPiece(new Knight(Player2Color, Board), 'b', 8);
            SetPiece(new Knight(Player2Color, Board), 'g', 8);
            SetPiece(new Bishop(Player2Color, Board), 'c', 8);
            SetPiece(new Bishop(Player2Color, Board), 'f', 8);
            SetPiece(new Queen(Player2Color, Board), 'd', 8);
            SetPiece(new King(Player2Color, Board), 'e', 8);
            SetPiece(new Pawn(Player2Color, Board), 'a', 7);
            SetPiece(new Pawn(Player2Color, Board), 'b', 7);
            SetPiece(new Pawn(Player2Color, Board), 'c', 7);
            SetPiece(new Pawn(Player2Color, Board), 'd', 7);
            SetPiece(new Pawn(Player2Color, Board), 'e', 7);
            SetPiece(new Pawn(Player2Color, Board), 'f', 7);
            SetPiece(new Pawn(Player2Color, Board), 'g', 7);
            SetPiece(new Pawn(Player2Color, Board), 'h', 7);
        }
    }
}

