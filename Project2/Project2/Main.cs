using System;
using UserChoise;
using System.Collections.Generic;
using System.Text;
namespace ComputerChoise
{
     using TheGame;
     using enumGameStatus;
     using Ex02.ConsoleUtils;
     class Program
    {
          public static void Main()
          {
               TheGame game;
               string newGameAnswer;
               do
               {
                    game = new TheGame();
                    game.RunTheGame();
                    Console.WriteLine("Would you like to start a new game? <Y/N>");
                    newGameAnswer = Console.ReadLine();
                    Screen.Clear();
               } while (game.getStatus() != eGameStatus.Quit && newGameAnswer == "Y");
               Console.WriteLine("bye bye");
          }
        
    }
}
