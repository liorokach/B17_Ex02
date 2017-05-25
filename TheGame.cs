using System;
using System.Collections.Generic;
using System.Text;

namespace TheGame
{
     using UserChoise;
     using ComputerChoise;
     using enumGameStatus;
     using Screen;

     public class TheGame
     {
          private UserChoise m_userControl;
          private ComputerChoise m_comChoise;
          private eGameStatus m_curGameStatus;
          private Screen m_gameBoard;
          private int m_maxGuesses;

          public TheGame()
          {
               m_maxGuesses = Screen.GetFromUserMaxGuesses();
               m_comChoise = new ComputerChoise(Screen.k_NumOfLetters);
               m_gameBoard = new Screen(m_maxGuesses, m_comChoise);
               m_userControl = m_gameBoard.GetUserRef();
               m_curGameStatus = new eGameStatus();
          }

          public void RunTheGame()
          {
               int curTry;
               m_gameBoard.PrintScreen(); //// print the board
               for (curTry = 0; curTry < m_maxGuesses && m_curGameStatus == eGameStatus.NotFinish; curTry++)
               {
                    DoIteration();
                    Screen.ClearScreen(); //// clear the board
                    m_gameBoard.PrintScreen(); //// print the board
               }

               if (m_curGameStatus == eGameStatus.NotFinish)
               {
                    m_curGameStatus = eGameStatus.Lose;
               }

               m_gameBoard.PrintStatusMsg(m_curGameStatus, curTry); // print the right msg(win , lose)
          }

          public void DoIteration()
          {
               string guess = Screen.GetValidGuess(); //// getValidGuess();
               if (guess == "Q")
               {
                    m_curGameStatus = eGameStatus.Quit; //// finish the game 
               }
               else
               {
                    m_userControl.AddGuess(guess);
                    string result = m_comChoise.CheckUserChoise(guess);
                    m_userControl.UpdateResult(result); // update the result for the guess
                    if (result == "V V V V")
                    {
                         m_curGameStatus = eGameStatus.Win;
                    }
               }
          }

          public eGameStatus getStatus()
          {
               return m_curGameStatus;
          }

          public void SetCurrGuessNumToZero()
          {
               m_userControl.SetCurrGueessNumToZero();
          }
     }
}
