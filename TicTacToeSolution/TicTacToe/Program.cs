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
            Console.WriteLine("*** Tic Tac Toe ***");
            Console.WriteLine("Welcome to the game Tic Tac Toe!");
            string player1 = Player(1);
            string player2 = Player(2);
            Console.WriteLine("Lets play\n");

            // print the map
            string[,] map = new string[3,3] 
            {
            {"0","0", "0"}, 
            {"0", "0", "0"}, 
            {"0" ,"0", "0"}
            };
            Mapgrid(map);
                   
            //Turn player 1
            while (!WinRow(map) && !WinColumn(map) && !WinDiagonal(map) && !MapFull(map))
            {
                Console.WriteLine("{0}. It is your turn!", player1);
                GameTurn(map, out int xChoice, out int yChoice, out bool result1, out bool result2);
                map[xChoice - 1, yChoice - 1] = "1";
                Mapgrid(map);
                Console.WriteLine();
                if (WinRow(map) || WinColumn(map) || WinDiagonal(map))
                {
                    break;
                }
                else
                {
                    //beurt speler 2
                    Console.WriteLine("{0}. It is your turn!", player2);
                    GameTurn(map, out xChoice, out yChoice, out result1, out result2);
                    map[xChoice - 1, yChoice - 1] = "2";
                    Mapgrid(map);
                    Console.WriteLine();
                }
            }

            //check who won
            if (WinRow(map))
            {
                if ((map[0, 0] == "1" && map[0, 1] == "1" && map[0,2] == "1") || (map[1, 0] == "1" && map[1, 1] == "1" && map[1,2] == "1") || (map[2, 0] == "1" && map[2, 1] == "1" && map[2,2] =="1"))
                {
                    Console.WriteLine("Well done {0}, YOU WON!",player1);
                }
                else
                {
                    Console.WriteLine("Well done {0}, YOU WON!",player2);
                }
            }
            if (WinColumn(map))
            {
                if ((map[0, 0] == "1" && map[1, 0] =="1" && map[2,0] == "1") || (map[0, 1] == "1" && map [1,1] =="1" && map[2, 1] == "1") || (map[0, 2] == "1") && map[1,2] =="1" && map[2, 2] == "1")
                {
                    Console.WriteLine("Well done {0}, YOU WON!", player1);
                }
                else
                {
                    Console.WriteLine("Well done {0}, YOU WON!", player2);
                }
            }
            if (WinDiagonal(map))
            {
                if (map[1,1] == "1")
                {
                    Console.WriteLine("Well done {0}, YOU WON!", player1);
                }
                else
                {
                    Console.WriteLine("Well done {0}, YOU WON!", player2);
                }
            }
            if (MapFull(map) && !WinRow(map) && !WinColumn(map) && !WinDiagonal(map))
            {
                Console.WriteLine("Map is full. It is a draw");
            }

            Console.WriteLine("Press <ENTER> to exit!");
            Console.ReadLine();
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
        private static void GameTurn(string[,] map, out int xChoice, out int yChoice, out bool result1, out bool result2)
        {
            do
            {
                Console.WriteLine("Enter an x coordinate (1,2 or 3): ");
                result1 = int.TryParse(Console.ReadLine(), out xChoice);
                while (!result1 || xChoice < 1 || xChoice > 3)
                {
                    Console.WriteLine("Wrong input, please enter 1, 2 or 3.");
                    result1 = int.TryParse(Console.ReadLine(), out xChoice);
                }
                Console.WriteLine("Enter a y coordinate (1, 2 or 3): ");
                result2 = int.TryParse(Console.ReadLine(), out yChoice);
                while (!result2 || yChoice < 1 || yChoice > 3)
                {
                    Console.WriteLine("Wrong input, please enter 1, 2 or 3.");
                    result2 = int.TryParse(Console.ReadLine(), out yChoice);
                }
                if (map[xChoice - 1, yChoice - 1] != "0")
                {
                    Console.WriteLine("This space is taken. Please, try again");
                }
            } while (map[xChoice - 1, yChoice - 1] != "0");
        }

        // method for calling the grid
        public static void Mapgrid(string[,] map)
        {
            Console.WriteLine(" 123");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == "0")
                    {
                        Console.Write(" ");
                    }
                    if (map[i, j] == "1")
                    {
                        Console.Write("X");
                    }
                    if (map[i, j] == "2")
                    {
                        Console.Write("O");
                    }
                }
                Console.WriteLine();
            }

        }
        // win check methods for three in a row, column and diagonally
        public static bool WinRow(string[,] map)
        {
            bool ret = false;
            if ((map[0, 0] != "0" && map[0, 0] == (map[0, 1]) && (map[0, 1]) == (map[0, 2])) || (map[1, 0] != "0" && map[1, 0] == (map[1, 1]) && (map[1, 1]) == (map[1, 2])) || (map[2, 0] != "0" && map[2, 0] == (map[2, 1]) && (map[2, 1]) == (map[2, 2])))
            {
                ret = true;
            }
            return ret;
        }

        public static bool WinColumn(string[,] map)
        {
            bool ret = false;
            if ((map[0, 0] != "0" && map[0, 0] == map[1, 0] && map[1, 0] == map[2, 0]) || (map[0, 1] != "0" && map[0, 1] == map[1, 1] && map[1, 1] == map[2, 1]) || (map[0, 2] != "0" && map[0, 2] == map[1, 2] && map[1, 2] == map[2, 2]))
            {
                ret = true;
            }
            return ret;
        }

        public static bool WinDiagonal(string[,] map)
        {
            bool ret = false;
            if ((map[1, 1] != "0" && map[0, 0] == map[1, 1] && map[1, 1] == map[2, 2]) || (map[1, 1] != "0" && map[0, 2] == map[1, 1] && map[1, 1] == map[2, 0]))
            {
                ret = true;
            }
            return ret;
        }

        //method for check if field is full
        public static bool MapFull(string [,] map)
        {
            bool ret = false;
            int emptySpotCount = 0;
            for (int i = 0; i<map.GetLength(0);i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if( map[i,j] == "0")
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

    }
}
