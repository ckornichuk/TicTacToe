using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        private readonly Board _board;
        private int _turns = 0;

        public Game(Board board)
        {
            _board = board;
        }

        public void Play()
        {
            Player player = new Player();

            Console.WriteLine("New game!");
            _board.DrawBoard();

            while (!_board.IsGameOver)
            {
                player = (player == Player.X
                    ? Player.O
                    : Player.X);

                bool turnTaken = false;
                while (!turnTaken)
                {
                    turnTaken = TakeTurn(player);
                    _board.DrawBoard();
                }

                _turns++;
            }

            if (_turns < 9)
                Console.WriteLine($"Player {player} won");
            else
                Console.WriteLine("Draw!");
            
            Console.WriteLine("Game over");
        }

        public bool TakeTurn(Player player)
        {
            Console.WriteLine($"Player {player.ToString()} go!");

            String place = Console.ReadLine();
            int row = int.Parse(place.Split(',')[0]);
            int col = int.Parse(place.Split(',')[1]);

            return _board.PlaceMark(player, row, col);
        }
    }
}
