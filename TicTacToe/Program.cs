﻿using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(new Board());
            game.Play();
            Console.ReadLine();
        }
    }
}
