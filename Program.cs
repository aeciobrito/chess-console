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

                

                Display.ShowBoard(gameManager.Board);
            }
            catch (BoardExeption e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
