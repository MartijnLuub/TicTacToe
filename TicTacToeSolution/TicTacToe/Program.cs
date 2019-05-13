using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string player1, player2;
            Intro(out player1, out player2);

            // print the map
            int[,] map = new int[3, 3];
            Mapgrid(map);

            //Turn player 1
            while (!WinRow(map) && !WinColumn(map) && !WinDiagonal(map) && !MapFull(map))
            {
                PrintTurnAnnouncment(player1);
                GameTurn(map, out int xChoice, out int yChoice);
                map[xChoice - 1, yChoice - 1] = 1;
                Mapgrid(map);
                Console.WriteLine();
                if (WinRow(map) || WinColumn(map) || WinDiagonal(map) || MapFull(map))
                {
                    break;
                }
                else
                {
                    //Turn player 2
                    PrintTurnAnnouncment(player2);
                    GameTurn(map, out xChoice, out yChoice);
                    map[xChoice - 1, yChoice - 1] = 2;
                    Mapgrid(map);
                    Console.WriteLine();
                }
            }

            //check who won
            if (WinRow(map))
            {
                if ((map[0, 0] == 1 && map[0, 1] == 1 && map[0, 2] == 1) ||
                    (map[1, 0] == 1 && map[1, 1] == 1 && map[1, 2] == 1) ||
                    (map[2, 0] == 1 && map[2, 1] == 1 && map[2, 2] == 1))
                {
                    PrintVictoryLine(player1);
                }
                else
                {
                    PrintVictoryLine(player2);
                }
            }
            if (WinColumn(map))
            {
                if ((map[0, 0] == 1 && map[1, 0] == 1 && map[2, 0] == 1) ||
                    (map[0, 1] == 1 && map[1, 1] == 1 && map[2, 1] == 1) ||
                    (map[0, 2] == 1) && map[1, 2] == 1 && map[2, 2] == 1)
                {
                    PrintVictoryLine(player1);
                }
                else
                {
                    PrintVictoryLine(player2);
                }
            }
            if (WinDiagonal(map))
            {
                if (map[1, 1] == 1)
                {
                    PrintVictoryLine(player1);
                }
                else
                {
                    PrintVictoryLine(player2);
                }
            }
            if (MapFull(map) && !WinRow(map) && !WinColumn(map) && !WinDiagonal(map))
            {
                Console.WriteLine("Map is full. Let's call it a draw");
            }

            Console.WriteLine("\nPress <ENTER> to exit!");
            Console.ReadLine();
        }

        //announces the player whoms turn it is
        private static void PrintTurnAnnouncment(string player)
        {
            Console.WriteLine("{0}. It is your turn!", player);
        }

        //intro tot the game
        private static void Intro(out string player1, out string player2)
        {
            Console.WriteLine("*** Tic Tac Toe ***");
            Console.WriteLine("Welcome to the game Tic Tac Toe!\n");
            player1 = Player(1);
            player2 = Player(2);
            Console.WriteLine("Lets play\n");
        }

        //method player
        public static string Player(int playerNumber)
        {
            Console.WriteLine("Player {0} please enter your name: ", playerNumber);
            string player = Console.ReadLine();
            if (playerNumber % 2 == 0)
            {
                Console.WriteLine("{0} you are the 'O' in the game.\n", player);
            }
            else
            {
                Console.WriteLine("{0} you are the 'X' in the game.\n", player);
            }
            return player;
        }

        // method for players turn
        private static void GameTurn(int[,] map, out int xChoice, out int yChoice)
        {
            do
            {
                Console.WriteLine("Enter an x coordinate (1,2 or 3): ");
                bool result1 = int.TryParse(Console.ReadLine(), out xChoice);
                while (!result1 || xChoice < 1 || xChoice > 3)
                {
                    Console.WriteLine("Wrong input, please enter 1, 2 or 3.");
                    result1 = int.TryParse(Console.ReadLine(), out xChoice);
                }
                Console.WriteLine("Enter a y coordinate (1, 2 or 3): ");
                bool result2 = int.TryParse(Console.ReadLine(), out yChoice);
                while (!result2 || yChoice < 1 || yChoice > 3)
                {
                    Console.WriteLine("Wrong input, please enter 1, 2 or 3.");
                    result2 = int.TryParse(Console.ReadLine(), out yChoice);
                }
                if (map[xChoice - 1, yChoice - 1] != 0)
                {
                    Console.WriteLine("This space is taken. Please, try again");
                }
            } while (map[xChoice - 1, yChoice - 1] != 0);
        }

        // method for calling the grid
        public static void Mapgrid(int[,] map)
        {
            Console.WriteLine(" 123");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[j, i] == 0)
                    {
                        Console.Write(" ");
                    }
                    if (map[j, i] == 1)
                    {
                        Console.Write("X");
                    }
                    if (map[j, i] == 2)
                    {
                        Console.Write("O");
                    }
                }
                Console.WriteLine();
            }
        }

        // win check methods for three in a row, column and diagonally
            public static bool WinRow(int[,] map)
            {
                bool ret = false;
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    if (map[i, 0] != 0)
                    {
                        if (map[i, 0] == map[i, 1] && map[i, 1] == map[i, 2])
                            ret = true;
                    }
                }                        
                return ret;
            }

            public static bool CheckThreeInColumn(int [,] map, int column)
            {
                return (map[0, column] != 0 && map[0, column] == map[1, column] && map[1, column] == map[2, column]);
            }

            public static bool WinColumn(int [,] map)
            {
            return (CheckThreeInColumn(map, 0) ||
                 CheckThreeInColumn(map, 1) ||
                 CheckThreeInColumn(map, 2));
            }

            public static bool WinDiagonal(int[,] map)
            {
                bool ret = false;
                if ((map[1, 1] != 0 && map[0, 0] == map[1, 1] && map[1, 1] == map[2, 2]) ||
                    (map[1, 1] != 0 && map[0, 2] == map[1, 1] && map[1, 1] == map[2, 0]))
                {
                    ret = true;
                }
                return ret;
            }

            //method for check if field is full
            public static bool MapFull(int[,] map)
            {
                bool ret = false;
                int emptySpotCount = 0;
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j] == 0)
                        {
                            emptySpotCount++;
                        }
                    }
                }
                if (emptySpotCount == 0)
                {
                    ret = true;
                }
                return ret;
            }

            //method for printing the victory line
            public static void PrintVictoryLine(string player)
            {
                Console.WriteLine("Well done {0}, YOU WON!", player);
            }
    }
}

