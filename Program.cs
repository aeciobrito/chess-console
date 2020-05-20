using System;
using BoardLayer;
using ChessLayer;

namespace ChessConsole
{
    class Program
    {
        //static int windowsSizeX = 40, windowsSizeY = 20;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Console.SetWindowSize(windowsSizeX, windowsSizeY);
            Console.Title = "CHESS";

            try
            {
                GameManager gameManager = new GameManager();

                while (!gameManager.GameOver)
                {
                    try
                    {
                        Console.Clear();
                        Display.ShowGame(gameManager);

                        Console.Write("SELECT A PIECE: ");
                        Vector2 selectedTile = Display.ReadPositions().ToVector2();

                        gameManager.SelectedPieceRestrictions(selectedTile);

                        bool[,] moveOptions = gameManager.Board.SelectPiece(selectedTile).MoveOptions();
                        Console.Clear();
                        Display.ShowBoard(gameManager.Board, moveOptions);
                        Console.WriteLine();

                        Console.Write("SELECT A DESTINY: ");
                        Vector2 destinationTile = Display.ReadPositions().ToVector2();
                        gameManager.DestinationPieceRestrictions(selectedTile, destinationTile);

                        gameManager.PlayerMove(selectedTile, destinationTile);
                    } catch (BoardExeption e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write("PRESS ANY KEY TO PLAY AGAIN");
                        Console.ReadLine();
                    }
                }     
            }
            catch (BoardExeption e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
