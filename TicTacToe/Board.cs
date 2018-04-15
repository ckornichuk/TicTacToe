using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Board
    {
        private string[][] _grid = new string[3][]
            {
                new string[3],
                new string[3],
                new string[3],
            };

        public bool IsGameOver { get; private set; } = false;

        public bool PlaceMark(Player player, int row, int col)
        {
            if (row > _grid.Length-1 || col > _grid.Length-1)
            {
                Console.WriteLine("Out of bounds!");

                return false;
            }

            if (_grid[row][col] != null)
            {
                Console.WriteLine("Box already occupied!");

                return false;
            }

            _grid[row][col] = player.ToString();

            CheckIfGameOver();

            return true;
        }

        private void CheckIfGameOver()
        {
            CheckRows();
            CheckColumns();
            CheckDiagonalsUp();
            CheckDiagonalsDown();
        }

        private void CheckRows()
        {
            for (int i = 0; i < _grid.Length; i++)
            {
                Dictionary<string, int> rowCheck = new Dictionary<string, int>()
                {
                    { Player.X.ToString(), 0 },
                    { Player.O.ToString(), 0 },

                };

                for (int j = 0; j < _grid[i].Length; j++)
                {
                    string curr = _grid[i][j];
                    if (curr != null)
                    {
                        rowCheck[curr]++;
                    }
                }

                if (rowCheck.ContainsValue(_grid.Length))
                    IsGameOver = true;
            }
        }

        private void CheckColumns()
        {
            for (int i = 0; i < _grid.Length; i++)
            {
                Dictionary<string, int> rowCheck = new Dictionary<string, int>()
                {
                    { Player.X.ToString(), 0 },
                    { Player.O.ToString(), 0 },

                };
                for (int j = 0; j < _grid[i].Length; j++)
                {
                    string curr = _grid[j][i];
                    if (curr != null)
                    {
                        rowCheck[curr]++;
                    }
                }

                if (rowCheck.ContainsValue(_grid.Length))
                    IsGameOver = true;
            }
        }

        private void CheckDiagonalsUp()
        {
            Dictionary<string, int> rowCheck = new Dictionary<string, int>()
            {
                { Player.X.ToString(), 0 },
                { Player.O.ToString(), 0 },

            };
            
            for (int i=0; i < _grid.Length; i++)
            {
                var curr = _grid[i][i];
                if (curr != null)
                {
                    rowCheck[curr]++;
                }
            }

            if (rowCheck.ContainsValue(_grid.Length))
                IsGameOver = true;

        }

        private void CheckDiagonalsDown()
        {
            Dictionary<string, int> rowCheck = new Dictionary<string, int>()
            {
                { Player.X.ToString(), 0 },
                { Player.O.ToString(), 0 },

            };

            for (int i = 0; i < _grid.Length; i++)
            {
                for (int j = _grid.Length-1; j < 0; j--)
                {
                    var curr = _grid[i][j];
                    if (curr != null)
                    {
                        rowCheck[curr]++;
                    }
                }
            }

            if (rowCheck.ContainsValue(_grid.Length))
                IsGameOver = true;
        }

        public void DrawBoard()
        {
            String s = String.Empty;
            for (int i = 0; i < _grid.Length; i++)
            {
                for (int j = 0; j < _grid[i].Length; j++)
                {
                    string box = _grid[i][j];

                    s += "|" + (box ?? " ");
                }
                s += "|" + Environment.NewLine;
            }

            Console.WriteLine(s);
        }
    }

    public enum Player
    {
        X,
        O,
    }
}
