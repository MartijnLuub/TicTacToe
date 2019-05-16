using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameBoard
    {
        private int[,] map;


        public GameBoard()
        {
            map = new int[3, 3];
        }

        public int[,] GetMap()
        {
            return map;
        }

        public void PrintMap(int[,] map)
        {
            Console.WriteLine(" 123");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[j, i] == 0) Console.Write(" ");
                    if (map[j, i] == 1) Console.Write("X");
                    if (map[j, i] == 2) Console.Write("O");
                }
                Console.WriteLine();
            }
        }

        private bool WinRow(int[,] map)
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

        private bool CheckThreeInColumn(int[,] map, int column)
        {
            return (map[0, column] != 0 && map[0, column] == map[1, column] && map[1, column] == map[2, column]);
        }

        private bool WinColumn(int[,] map)
        {
            return (CheckThreeInColumn(map, 0) ||
                 CheckThreeInColumn(map, 1) ||
                 CheckThreeInColumn(map, 2));
        }

        private bool WinDiagonal(int[,] map)
        {

            return ((map[1, 1] != 0 && map[0, 0] == map[1, 1] && map[1, 1] == map[2, 2]) ||
                (map[1, 1] != 0 && map[0, 2] == map[1, 1] && map[1, 1] == map[2, 0]));
        }

        public bool WinGame(int [,] map)
        {
            return (WinRow (map) || WinColumn(map) || WinDiagonal(map));
        }

        
        public string CheckWhoWins(int[,] map, string player1, string player2)
        {
            if (WinRow(map))
            {
                if ((map[0, 0] == 1 && map[0, 1] == 1 && map[0, 2] == 1) ||
                    (map[1, 0] == 1 && map[1, 1] == 1 && map[1, 2] == 1) ||
                    (map[2, 0] == 1 && map[2, 1] == 1 && map[2, 2] == 1))
                {
                    return player1;
                }
                else return player2;
            }
            if (WinColumn(map))
            {
                if ((map[0, 0] == 1 && map[1, 0] == 1 && map[2, 0] == 1) ||
                    (map[0, 1] == 1 && map[1, 1] == 1 && map[2, 1] == 1) ||
                    (map[0, 2] == 1) && map[1, 2] == 1 && map[2, 2] == 1)
                {
                    return player1;
                }
                else return player2;
            }
            if (WinDiagonal(map))
            {
                if (map[1, 1] == 1) return player1;
                else return player2;
            }
            return "";
        }

        //method for check if field is full
        public bool MapFull(int[,] map)
        {
            
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
            return emptySpotCount == 0;
        }
    }
}
