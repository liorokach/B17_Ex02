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

          public Screen(int i_maxNumGuess, ComputerChoise i_compChoise)
          {
               m_compChoise = i_compChoise;
               m_maxNumGuesses = i_maxNumGuess;
               m_userChoise = new UserChoise(m_maxNumGuesses); ;
          }

          public static int GetFromUserMaxGuesses()
          {
               bool valid = false;
               int maxGuesses;
               do
               {
                    Console.WriteLine("please type a maximum number of guesses(integer between 4 to 10)");
                    string maxGuessInStr = Console.ReadLine();
                    valid = int.TryParse(maxGuessInStr, out maxGuesses);
                    valid = maxGuesses >= 4 && maxGuesses <= 10;
               }
               while (!valid);
               return maxGuesses;
          }

          public static bool CheckGuessVaildation(string i_guess)
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

          public static string GetValidGuess()
          {
               bool valid = false;
               string guess;
               do
               {
                    Console.WriteLine("please type your next guess <ABCD> or 'Q' to quit");
                    guess = Console.ReadLine();
                    valid = CheckGuessVaildation(guess);
                    if (guess == "Q")
                    {
                         valid = true;
                    }
               }
               while (!valid);
               return guess;
          }

          public static void ClearScreen()
          {
               Ex02.ConsoleUtils.Screen.Clear();
          }

          public static void EndOfGameMsg()
          {
               Console.WriteLine("Thank You For Playing , Have a nice day! bye bye!");
          }

          public static bool IsUserWantNewGame()
          {
               string newGameAnswer = string.Empty;
               bool validAnswer = false;
               while (!validAnswer)
               {
                    Console.WriteLine("would you like to start a new game? <Y/N>");
                    newGameAnswer = Console.ReadLine();
                    validAnswer = newGameAnswer == "Y" || newGameAnswer == "N";
               }
               ClearScreen();
               return newGameAnswer == "Y";
          }

          public UserChoise GetUserRef()
          {
               return m_userChoise;
          }

          public void PrintStatusMsg(eGameStatus i_curGameStatus, int i_curTry)
          {
               if (i_curGameStatus == eGameStatus.Win)
               {
                    Console.Write("You guessed after ");
                    Console.Write(i_curTry.ToString());
                    Console.WriteLine(" steps!");
               }
               else if (i_curGameStatus == eGameStatus.Lose)
               {
                    Console.WriteLine("No more guesses allowed. You Lost.");
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
     }
}