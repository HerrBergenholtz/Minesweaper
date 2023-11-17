using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweaper
{
    class Program
    {
        public static void Main()
        {
            string[,] gameBoard = new string[6, 6];
            gameBoard[0, 0] = "[]";
            gameBoard[1, 0] = "[]";
            gameBoard[2, 0] = "[]";
            gameBoard[3, 0] = "[]";
            gameBoard[4, 0] = "[]";
            gameBoard[5, 0] = "[]";
            gameBoard[0, 1] = "[]";
            gameBoard[1, 1] = "[]";
            gameBoard[2, 1] = "[]";
            gameBoard[3, 1] = "[]";
            gameBoard[4, 1] = "[]";
            gameBoard[5, 1] = "[]";
            gameBoard[0, 2] = "[]";
            gameBoard[1, 2] = "[]";
            gameBoard[2, 2] = "[]";
            gameBoard[3, 2] = "[]";
            gameBoard[4, 2] = "[]";
            gameBoard[5, 2] = "[]";
            gameBoard[0, 3] = "[]";
            gameBoard[1, 3] = "[]";
            gameBoard[2, 3] = "[]";
            gameBoard[3, 3] = "[]";
            gameBoard[4, 3] = "[]";
            gameBoard[5, 3] = "[]";
            gameBoard[0, 4] = "[]";
            gameBoard[1, 4] = "[]";
            gameBoard[2, 4] = "[]";
            gameBoard[3, 4] = "[]";
            gameBoard[4, 4] = "[]";
            gameBoard[5, 4] = "[]";
            gameBoard[0, 5] = "[]";
            gameBoard[1, 5] = "[]";
            gameBoard[2, 5] = "[]";
            gameBoard[3, 5] = "[]";
            gameBoard[4, 5] = "[]";
            gameBoard[5, 5] = "[]";

            int x = 1;
            int y = 2;
            string svar = VisaMeddelande(gameBoard, x, y);

            while (svar != "exit")
            {
                if (y < 0)
                {
                    y = 0;
                    Unavailable();
                }
                else if (y > 5)
                {
                    y = 5;
                    Unavailable();
                }
                else if (x < 0)
                {
                    x = 0;
                    Unavailable();
                }
                else if (x > 5)
                {
                    x = 5;
                    Unavailable();
                }

                switch (svar)
                {
                    case "w":
                        y--;
                        svar = VisaMeddelande(gameBoard, x, y);
                        break;
                    case "a":
                        x--;
                        svar = VisaMeddelande(gameBoard, x, y);
                        break;
                    case "s":
                        y++;
                        svar = VisaMeddelande(gameBoard, x, y);
                        break;
                    case "d":
                        x++;
                        svar = VisaMeddelande(gameBoard, x, y);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måate ha en korrekt input!");
                        Console.WriteLine("Klicka enter för att börja om");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        Main();
                        break;
                }
            }
            Console.WriteLine("Tack för att du spelade!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static string VisaMeddelande(string[,] gameBoard, int x, int y)
        {
            Console.Clear();
            if (y < 0)
            {
                y = 0;
                Unavailable();
            }
            else if (y > 5)
            {
                y = 5;
                Unavailable();
            }
            else if (x < 0)
            {
                x = 0;
                Unavailable();
            }
            else if (x > 5)
            {
                x = 5;
                Unavailable();
            }


            Console.WriteLine("Du befinner dig på en gameBoard av bokstäver.");
            Console.WriteLine($"Koordinat: {x}, {y}");
            Console.WriteLine($"Bokstav: {gameBoard[x, y]}");
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                Console.WriteLine(" -----------------------------");
                Console.Write("| ");
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (j == x && i == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[]");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" | ");
                    }
                    else
                    {
                        Console.Write(gameBoard[j, i] + " | ");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" -----------------------------");
            Console.WriteLine("Vart vill du gå? (wasd)(skriv \"exit\" om du vill avsluta programmet)");
            string svar = Console.ReadLine();
            return svar;
        }

        public static void Unavailable()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du kan inte gå åt det hållet!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

