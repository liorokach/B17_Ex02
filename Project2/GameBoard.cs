using System;
using System.Collections.Generic;
using System.Text;

namespace GameBoard
{
     public class GameBoard
     {
          private List<string> m_guess = new List<string>();
          private List<string> m_result = new List<string>();
          private int m_pinsColumLength;
          private int m_resultColumLength;

          public GameBoard(int i_maxGuess, int i_guessColumLength, int i_resultColumLength)
          {
               m_pinsColumLength = i_guessColumLength;
               m_resultColumLength = i_resultColumLength;
               m_guess.Add("Pins:");
               for (int i = i_guessColumLength - m_guess[0].Length; i > 0; i--)  
               {
                    m_guess[0] += " ";
               }

               m_result.Add("Result:");
               for (int i = i_resultColumLength - m_result[0].Length; i > 0; i--) 
               {
                    m_result[0] += " ";
               }

               m_guess.Add(" # # # #");
               for (int i = i_guessColumLength - m_guess[1].Length; i > 0; i--)
               {
                    m_guess[1] += " ";
               }

               m_result.Add(string.Empty);
               for (int i = i_resultColumLength - m_result[1].Length; i > 0; i--)
               {
                    m_result[1] += " ";
               }
          }

          public void UpdateBoard(string i_userguess, string i_result)
          {
               string guess = " ", result = string.Empty;
               guess += i_userguess;
               result += i_result;
               for (int i = m_pinsColumLength - guess.Length; i > 0; i--)
               { 
                    guess += " ";
               }

               for (int i = m_resultColumLength - result.Length; i > 0; i--) 
               {
                    result += " ";
               }

               m_guess.Add(guess);
               m_result.Add(result);
          }

          public void PrintLineInBoard(int i_line)
          {
               Console.Write("|");
               Console.Write(m_guess[i_line]);
               Console.Write("|");
               Console.Write(m_result[i_line]);
               Console.WriteLine("|");
          }
     }
}
