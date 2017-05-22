using System;
using System.Collections.Generic;
using System.Text;

namespace Screen
{
    using UserChoise;
    using enumGameStatus;
    using ComputerChoise;

     internal class Screen
     {
          private ComputerChoise m_compChoise;
          private UserChoise m_userChoise;
          private int m_maxNumGuesses;

          public Screen(int i_maxNumGuess, ComputerChoise i_compChoise, UserChoise i_userChoise)
          {
               m_compChoise = i_compChoise;
               m_userChoise = i_userChoise;
               m_maxNumGuesses = i_maxNumGuess;
          }

          public void PrintStatusMsg(eGameStatus i_curGameStatus, int i_curTry)
          {
               if (i_curGameStatus == eGameStatus.Win)
               {
                    Console.Write("You guessed after ");
                    Console.Write(i_curTry.ToString());
                    Console.WriteLine(" steps!");

                    Console.WriteLine("would you like to start a new game? <Y/N>");
               }
               else if (i_curGameStatus == eGameStatus.Lose)
               {
                    Console.WriteLine("No more guesses allowed. You Lost.");
                    Console.WriteLine("would you like to start a new game? <Y/N>");
               }
               else
               {
                    Console.WriteLine("Please type your next guess <A B C D> or 'Q'");
               }
          }

          public void PrintScreen()
          {
               PrintThreeFirstLines();
               printLineSeperator();
               int line = m_maxNumGuesses * 2;
               for (int i = 0; i < line; i++)
               {
                    if (i % 2 == 0)
                    {
                         Console.Write("|");
                         printLineGuess(i / 2);
                         Console.Write("|");
                         printLineResult(i / 2);
                         Console.WriteLine("|");
                    }
                    else
                    {
                         printLineSeperator();
                    }
               }
          }

          private void PrintThreeFirstLines()
          {
               int compChoiseLen = m_compChoise.GetComputerChoiseLenght();
               Console.WriteLine("|Pins:    |Result:|");
               printLineSeperator();
               int col = (compChoiseLen * 2) + 1;
               Console.Write("|");
               for (int i = 0; i < col; i++)
               {
                    if (i % 2 == 0)
                    {
                         Console.Write(" ");
                    }
                    else
                    {
                         Console.Write("#");
                    }
               }

               Console.Write("|");
               col = (compChoiseLen * 2) - 1;
               for (int i = 0; i < col; i++)
               {
                    Console.Write(" ");
               }

               Console.WriteLine("|");
          }

          private void printLineSeperator()
          {
               int compChoiseLen = m_compChoise.GetComputerChoiseLenght();
               int col = (compChoiseLen * 2) + 1; // size of guess
               Console.Write("|");
               for (int i = 0; i < col; i++)
               {
                    Console.Write("=");
               }

               Console.Write("|"); // the | between the pins and result
               col = (compChoiseLen * 2) - 1; // size of guess
               for (int i = 0; i < col; i++)
               {
                    Console.Write("=");
               }

               Console.WriteLine("|");
          }

          private void printLineResult(int i_line)
          {
               int col = (m_compChoise.GetComputerChoiseLenght() * 2) - 1; // size of guess
               Console.Write(m_userChoise.GetAllResults()[i_line]);
               for (int i = 0; i < col - m_userChoise.GetAllResults()[i_line].Length; i++)
               {
                    Console.Write(" ");
               }
          }

          private void printLineGuess(int i_line)
          {
               int compChoiseLen = m_compChoise.GetComputerChoiseLenght();
               int col = (compChoiseLen * 2) + 1; // size of guess
               for (int i = 0; i < col; i++)
               {
                    if (i % 2 == 0)
                    {
                         Console.Write(" ");
                    }
                    else
                    {
                         if (m_userChoise.GetAllGuesses()[i_line].Equals(string.Empty))
                         {
                              Console.Write(" ");
                         }
                         else
                         {
                              Console.Write(m_userChoise.GetAllGuesses()[i_line][i / 2]);
                         }
                    }
               }
          }

          public void clearScreen()
          {
               Ex02.ConsoleUtils.Screen.Clear();
          }
     }
}