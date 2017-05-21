using System;
using System.Collections.Generic;
using System.Text;

namespace Screen
{
     using UserChoise;
     using enumGameStatus;

     class Screen
     {
          UserChoise m_userChoise;
          int m_maxNumGuesses;
          public Screen(int i_maxNumGuess , UserChoise i_userChoise)
          {
               m_userChoise = i_userChoise;
               m_maxNumGuesses = i_maxNumGuess;
          }

          public void PrintStatusMsg(eGameStatus i_curGameStatus, int i_curTry)
          {
               if (i_curGameStatus == eGameStatus.Win)
               {
                    Console.WriteLine("You guessed after ", i_curTry, " steps!");
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
               int line = (m_maxNumGuesses) * 2;
               for (int i = 0; i < line; i++)
               {
                    if (i % 2 == 0)
                    {
                         Console.Write("|");
                         printLineGuess(i / 2);
                         Console.Write("|");
                         printLineResult(i / 2);
                         Console.Write("|");
                    }
                    else
                    {
                         Console.Write("|");
                         printLineSeperator();
                         Console.Write("|");
                    }
                    Console.WriteLine();
               }
          }

          public void PrintThreeFirstLines()
          {
               int colGuess = (m_userChoise.GetLastGuess().Length * 2) + 1 - 5;// 5 is the size of pins
               int colRes = (m_userChoise.GetLastGuess().Length * 2) - 1 - 7;// 5 is the size of pins
               string firstLines = string.Format("|Pins:{0}|Result:{1}", colGuess, colRes);
               printLineSeperator();
               int col = (m_userChoise.GetLastGuess().Length * 2) + 1;
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
               col = (m_userChoise.GetLastGuess().Length * 2) - 1;
               for (int i = 0; i < col; i++)
               {
                    Console.Write(" ");
               }
               Console.Write("|");
          }

          public void printLineSeperator()
          {
               int col = (m_userChoise.GetLastGuess().Length * 2) + 1; // size of guess
               for (int i = 0; i < col; i++)
               {
                    Console.Write("=");
               }
               Console.Write("|"); // the | between the pins and result

               col = (m_userChoise.GetLastResult().Length * 2) - 1; // size of guess

               for (int i = 0; i < col; i++)
               {
                    Console.Write("=");
               }
          }

          public void printLineResult(int i_line)
          {
               int col = (m_userChoise.GetLastResult().Length * 2) - 1; // size of guess
               for (int i = 0; i < col; i++)
               {
                    if (i % 2 == 0)
                    {
                         Console.Write(m_userChoise.GetAllResults()[i_line][i / 2]);
                    }
                    else
                    {
                         Console.Write(" ");
                    }

               }
          }

          public void printLineGuess(int i_line)
          {
               int col = (m_userChoise.GetLastGuess().Length * 2) + 1; // size of guess
               for (int i = 0; i < col; i++)
               {
                    if (i % 2 == 0)
                    {
                         Console.Write(" ");
                    }
                    else
                    {
                         Console.Write(m_userChoise.GetAllGuesses()[i_line][i / 2]);
                    }
               }
          }

          public void clearScreen()
          {
               Ex02.ConsoleUtils.Screen.Clear();
          }
     }
}