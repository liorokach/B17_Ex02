using System;
using System.Collections.Generic;
using System.Text;
namespace UserChoise
{
     using ComputerChoise;
     class UserChoise
     {
          private int m_CurrentNumGuess;
          private List<string> m_strGuess;
          private List<string> m_pinResult;
          ComputerChoise m_compStr;
          public UserChoise(int i_numberOfLetters)
          {
               m_compStr = new ComputerChoise(i_numberOfLetters);
               m_strGuess = new List<string>();
               m_pinResult = new List<string>();
          } 
          public void AddGuess(string i_userStrGuess)
          {
               m_CurrentNumGuess++;
               m_strGuess.Add(i_userStrGuess);
               UpdateResult((m_compStr.CheckUserChoise(i_userStrGuess)));
          }
          public void UpdateResult(string i_guessResult)
          {
               m_pinResult.Add(i_guessResult);
          }
          public string GetGuess()
          {
               return m_strGuess[m_strGuess.Count-1];
          }
          public string GetResult()
          {
               return m_pinResult[m_pinResult.Count - 1];
          }
          public string GetCompChoise()
          {
               return m_compStr.GetChoise();
          }

     }
}
