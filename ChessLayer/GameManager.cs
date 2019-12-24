using System;
using BoardLayer;

namespace ChessLayer
{
    class GameManager
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        private ConsoleColor _player1Color, _player2Color;
        public ConsoleColor CurrentPlayer { get; private set; }

        public GameManager()
        {
            Board = new Board(new Vector2(8, 8));
            Turn = 1;
            _player1Color = ConsoleColor.Blue;
            _player2Color = ConsoleColor.Red;
            CurrentPlayer = _player1Color;
            SetPieces();
        }

        public void ChangePosition(Vector2 selectedTile, Vector2 destinationTile)
        {
            //IF PIECE != NULL??
            Piece piece = Board.RemovePiece(selectedTile);
            piece.MoveIncrease();
            Piece removedPiece = Board.RemovePiece(destinationTile);
            Board.PutPiece(piece, destinationTile);
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

        private void SetPieces()
        {
            Board.PutPiece(new Rook(_player1Color, Board), new ChessPosition('a', 1).ToVector2());
            Board.PutPiece(new Rook(_player1Color, Board), new ChessPosition('h', 1).ToVector2());
            Board.PutPiece(new Knight(_player1Color, Board), new ChessPosition('b', 1).ToVector2());
            Board.PutPiece(new Knight(_player1Color, Board), new ChessPosition('g', 1).ToVector2());
            Board.PutPiece(new Bishop(_player1Color, Board), new ChessPosition('c', 1).ToVector2());
            Board.PutPiece(new Bishop(_player1Color, Board), new ChessPosition('f', 1).ToVector2());
            Board.PutPiece(new Queen(_player1Color, Board), new ChessPosition('d', 1).ToVector2());
            Board.PutPiece(new King(_player1Color, Board), new ChessPosition('e', 1).ToVector2());
            Board.PutPiece(new Pawn(_player1Color, Board), new ChessPosition('a', 2).ToVector2());
            Board.PutPiece(new Pawn(_player1Color, Board), new ChessPosition('b', 2).ToVector2());
            Board.PutPiece(new Pawn(_player1Color, Board), new ChessPosition('c', 2).ToVector2());
            Board.PutPiece(new Pawn(_player1Color, Board), new ChessPosition('d', 2).ToVector2());
            Board.PutPiece(new Pawn(_player1Color, Board), new ChessPosition('e', 2).ToVector2());
            Board.PutPiece(new Pawn(_player1Color, Board), new ChessPosition('f', 2).ToVector2());
            Board.PutPiece(new Pawn(_player1Color, Board), new ChessPosition('g', 2).ToVector2());
            Board.PutPiece(new Pawn(_player1Color, Board), new ChessPosition('h', 2).ToVector2());

            Board.PutPiece(new Rook(_player2Color, Board), new ChessPosition('a', 8).ToVector2());
            Board.PutPiece(new Rook(_player2Color, Board), new ChessPosition('h', 8).ToVector2());
            Board.PutPiece(new Knight(_player2Color, Board), new ChessPosition('b', 8).ToVector2());
            Board.PutPiece(new Knight(_player2Color, Board), new ChessPosition('g', 8).ToVector2());
            Board.PutPiece(new Bishop(_player2Color, Board), new ChessPosition('c', 8).ToVector2());
            Board.PutPiece(new Bishop(_player2Color, Board), new ChessPosition('f', 8).ToVector2());
            Board.PutPiece(new Queen(_player2Color, Board), new ChessPosition('d', 8).ToVector2());
            Board.PutPiece(new King(_player2Color, Board), new ChessPosition('e', 8).ToVector2());
            Board.PutPiece(new Pawn(_player2Color, Board), new ChessPosition('a', 7).ToVector2());
            Board.PutPiece(new Pawn(_player2Color, Board), new ChessPosition('b', 7).ToVector2());
            Board.PutPiece(new Pawn(_player2Color, Board), new ChessPosition('c', 7).ToVector2());
            Board.PutPiece(new Pawn(_player2Color, Board), new ChessPosition('d', 7).ToVector2());
            Board.PutPiece(new Pawn(_player2Color, Board), new ChessPosition('e', 7).ToVector2());
            Board.PutPiece(new Pawn(_player2Color, Board), new ChessPosition('f', 7).ToVector2());
            Board.PutPiece(new Pawn(_player2Color, Board), new ChessPosition('g', 7).ToVector2());
            Board.PutPiece(new Pawn(_player2Color, Board), new ChessPosition('h', 7).ToVector2());
        }
    }
}

