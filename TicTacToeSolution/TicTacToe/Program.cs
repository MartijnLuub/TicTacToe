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
            var gameBoard = new GameBoard();
            Intro(out player1, out player2);

            int[,] map = gameBoard.GetMap();
            gameBoard.PrintMap(map);
            string winner;

            while (!gameBoard.WinGame(map) && !gameBoard.MapFull(map))
            {
                PlayerTurn(gameBoard, map, player1, 1);
                if (gameBoard.WinGame(map)) break;
                else PlayerTurn(gameBoard, map, player2, 2);
            }
            if (gameBoard.WinGame(map))
            {
                winner = gameBoard.CheckWhoWins(map, player1, player2);
                PrintVictoryLine(winner);

            }
            if (gameBoard.MapFull(map))
            {
                Console.WriteLine("Map is full. Let's call it a draw");
            }
            Console.WriteLine("\nPress <ENTER> to exit!");
            Console.ReadLine();
        }

        //announces the player whoms turn it is
        static void PrintTurnAnnouncment(string player)
        {
            Console.WriteLine("{0}. It is your turn!", player);
        }

        //intro tot the game
        static void Intro(out string player1, out string player2)
        {
            Console.WriteLine("*** Tic Tac Toe ***");
            Console.WriteLine("Welcome to the game Tic Tac Toe!\n");
            player1 = Player(1);
            player2 = Player(2);
            Console.WriteLine("Lets play\n");
        }

        //method player
        static string Player(int playerNumber)
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
        static void GameTurn(int[,] map, out int xChoice, out int yChoice)
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

        static void PlayerTurn(GameBoard gameBoard, int [,] map, string player, int playerNumber)
        {
            PrintTurnAnnouncment(player);
            GameTurn(map, out int xChoice, out int yChoice);
            map[xChoice - 1, yChoice - 1] = playerNumber;
            gameBoard.PrintMap(map);
            Console.WriteLine();
        }
            //method for printing the victory line
        static void PrintVictoryLine(string player)
        {
            Console.WriteLine("Well done {0}, YOU WON!", player);
        }
    }
}

