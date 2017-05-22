using System;

namespace ComputerChoise
{
    using TheGame;
    using enumGameStatus;
    using Ex02.ConsoleUtils;

    internal class Program
    {
        public static void Main()
        {
            TheGame game;
            string newGameAnswer;
            do
            {
                game = new TheGame();
                game.RunTheGame();
                newGameAnswer = Console.ReadLine();
                game.SetCurrGuessNumToZero();
                Screen.Clear();
            }
            while (game.getStatus() != eGameStatus.Quit && newGameAnswer == "Y");
            Console.WriteLine("bye bye");
        }
    }
}
