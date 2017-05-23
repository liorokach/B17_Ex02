using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerChoise
{
     public struct ComputerChoise
     {
          private string m_compChoise;

          public static string GenerateRndStr(int i_numberOfLetters)
          {
               string randomStr = string.Empty;
               Random random = new Random();
               char letter;
               for (int i = 0; i < i_numberOfLetters; i++)
               {
                    int offset;
                    do
                    {
                         offset = random.Next(0, 8);
                         letter = (char)('A' + offset);
                    }
                    while (randomStr.Contains(letter.ToString()));
                    randomStr += letter.ToString();
               }

               return randomStr;
          }

          public ComputerChoise(int i_numberOfLetters)
          {
               m_compChoise = GenerateRndStr(i_numberOfLetters);
          }

          public string GetChoise()
          {
               return m_compChoise;
          }

          public string CheckUserChoise(string i_userChoise)
          {
               int indexResult;
               string scoreStr = string.Empty;
               for (int i = 0; i < i_userChoise.Length; i++)
               {
                    indexResult = m_compChoise.IndexOf(i_userChoise[i]);
                    if (indexResult == i)
                    {
                         scoreStr = scoreStr.Insert(0, "V ");
                    }
                    else if (indexResult != -1)
                    {
                         scoreStr += "X ";
                    }
               }

               if (scoreStr.Length == 8)
               {
                    scoreStr = scoreStr.Substring(0, 7);
               }

               return scoreStr;
          }

          public int GetComputerChoiseLenght()
          {
               return m_compChoise.Length;
          }
     }
}
