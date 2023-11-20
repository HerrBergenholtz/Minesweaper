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
            int[,] mines = new int[,]
            {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };

            string[,] gameBoard = new string[,]
            {
                { "[]", "[]", "[]", "[]", "[]", "[]" },
                { "[]", "[]", "[]", "[]", "[]", "[]" },
                { "[]", "[]", "[]", "[]", "[]", "[]" },
                { "[]", "[]", "[]", "[]", "[]", "[]" },
                { "[]", "[]", "[]", "[]", "[]", "[]" }
            };

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
                    case "f":
                        VäljRuta(mines, gameBoard, x, y);
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
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                Console.WriteLine(" -----------------------------");
                Console.Write("| ");
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (j == x && i == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(gameBoard[x, y]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" | ");
                    }
                    else
                    {
                        Console.Write(gameBoard[i, j] + " | ");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" -----------------------------");
            Console.WriteLine("Vart vill du gå? (wasd)(skriv \"exit\" om du vill avsluta programmet)");
            string svar = Console.ReadLine();
            return svar;
        }

        public static void VäljRuta(int[,] mines, string[,] gameBoard, int x, int y)
        {
            if (mines[y, x] == 1)
            {
                GameOver();
            }
            else
            {
                NoMine(gameBoard, mines, x, y);
            }
        }

        public static void GameOver()
        {
            Console.WriteLine("Tyvärr, du klickade på en mina");
        }

        public static void NoMine(string[,] gameBoard, int[,] mines, int x, int y)
        {
            /*for (int i = 0; i < mines.GetLength(0); i++)
            {
                for (int j = 0; j < mines.GetLength(1); j++)
                {
                    Console.Write(mines[x, y]);
                }
                Console.WriteLine("");
            }
            Console.ReadKey();*/
            Console.WriteLine(mines[x, y]);
            Console.WriteLine($"{x},{y}");
            int minorjämte = 0;
            if (mines[y--, x--] == 1)
            {
                minorjämte++;
            }
            else if (mines[y, x--] == 1)
            {
                minorjämte++;
            }
            else if (mines[y++, x--] == 1)
            {
                minorjämte++;
            }
            else if (mines[y++, x] == 1)
            {
                minorjämte++;
            }
            else if (mines[y++, x++] == 1)
            {
                minorjämte++;
            }
            else if (mines[y, x++] == 1)
            {
                minorjämte++;
            }
            else if (mines[y--, x++] == 1)
            {
                minorjämte++;
            }
            else if (mines[y--, x] == 1)
            {
                minorjämte++;
            }

        }

        public static void Unavailable()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du kan inte gå åt det hållet!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}