using System;
using BoardLayer;
using ChessLayer;

namespace ChessConsole
{
    class Program
    {
        static int windowsSizeX = 40, windowsSizeY = 15;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(windowsSizeX, windowsSizeY);
            Console.Title = "Chess";

            try
            {
                GameManager gameManager = new GameManager();

                while (true)
                {
                    Console.Clear();
                    Display.ShowBoard(gameManager.Board);
                    
                    Console.WriteLine();
                    Console.Write("Selecet a piece: ");
                    Vector2 startPoint = Display.ReadPositions().ToVector2();

                    bool[,] moveOptions = gameManager.Board.SelectPiece(startPoint).MoveOptions();
                    Console.Clear();
                    Display.ShowBoard(gameManager.Board, moveOptions);
                    
                    Console.Write("Selecet a destiny: ");
                    Vector2 endPoint = Display.ReadPositions().ToVector2();
                    gameManager.Move(startPoint, endPoint);
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
