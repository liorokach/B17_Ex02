using System;
using System.Collections.Generic;
using System.Text;

namespace TheGame
{
     using UserChoise;
     using ComputerChoise;
     using GameBoard;
     using enumGameStatus;
     using Screen;
     class TheGame
     {
          private UserChoise m_userControl;
          private ComputerChoise m_comChoise;
          //private GameBoard m_gameBoard; // need to be the screen
          private enumGameStatus m_curGameStatus;
          private Screen m_gameBoard;
          private int m_maxGuesses;
          public TheGame()
          {
               m_maxGuesses = GetFromUserMaxGuesses();
               m_comChoise = new ComputerChoise(4);
               m_userControl = new UserChoise();
               m_gameBoard = new Screen(m_maxGuesses, m_userControl);
               m_curGameStatus = new enumGameStatus();
          }
          public static int GetFromUserMaxGuesses()
          {
               bool valid = false;
               int maxGuesses;
               do
               {
                    Console.WriteLine("please type a maximum number of guesses(integer between 4 to 10)");
                    string maxGuessInStr = Console.ReadLine();
                    valid = int.TryParse(maxGuessInStr,out maxGuesses);
                    valid = (maxGuesses >= 4 && maxGuesses <= 10);
               } while (!valid);
               return maxGuesses;
          }
          public void RunTheGame()
          {
               int curTry;
               for (curTry = 0; curTry < m_maxGuesses && m_curGameStatus == enumGameStatus.notFinish; curTry++)
               {
                   // m_gameBoard.PrintScreen();///print the board
                    DoIteration();
                    if (curTry != m_maxGuesses - 1 && m_curGameStatus == enumGameStatus.notFinish)
                    {
                         m_gameBoard.clearScreen();
                    }
               }
               if (m_curGameStatus == enumGameStatus.notFinish)
               {
                    m_curGameStatus = enumGameStatus.lose;
               }
               m_gameBoard.PrintStatusMsg(m_curGameStatus,curTry); //print the right msg(win , lose)
          }
          public void DoIteration()
          {
               string guess = getValidGuess();
               if (m_curGameStatus != enumGameStatus.quit)
               {
                    m_userControl.AddGuess(guess);
                    string result = m_comChoise.CheckUserChoise(guess);
                    m_userControl.UpdateResult(result); // update the result for the guess
                    if (result == "V V V V")
                    {
                         m_curGameStatus = enumGameStatus.win;
                    }
               }
               //add guess to board
          }
          public string getValidGuess()
          {
               bool valid = false;
               string guess;
               do
               {
                    Console.WriteLine("please type your next guess <A B C D> or 'Q' to quit");
                    guess = Console.ReadLine();
                    valid = checkGuessVaildation(guess);
                    if (guess == "Q") 
                    {
                         m_curGameStatus = enumGameStatus.quit;///finish the game 
                         valid = true;
                    }
               } while (!valid);

               return guess;
          }
          public static bool checkGuessVaildation(string i_guess)
          {
               bool validResult = true;
               int countLetters = 0;
               foreach (char letter in i_guess)
               {
                    if (letter >= 'A' && letter <= 'H')
                    {
                         countLetters++;
                    }
                    else
                    {
                         validResult = false;
                    }
               }
               if (countLetters != 4)
               {
                    validResult = false;
               }
               return validResult;
          }
          public enumGameStatus getStatus()
          {
               return m_curGameStatus;
          }
     }
}
