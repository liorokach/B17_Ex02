using System;
using System.Collections.Generic;
using System.Text;
namespace UserChoise
{
     class UserChoise
     {
          private List<string> m_strGuess;
          private List<string> m_pinResult;
          public UserChoise()
          {
               m_strGuess = new List<string>();
               m_pinResult = new List<string>();
          } 
          public void AddGuess(string i_userStrGuess)
          {
               m_strGuess.Add(i_userStrGuess);
          }
          public void UpdateResult(string i_guessResult)
          {
               m_pinResult.Add(i_guessResult);
          }
          public string GetLastGuess()
          {
               return m_strGuess[m_strGuess.Count-1];
          }
          public string GetLastResult()
          {
               return m_pinResult[m_pinResult.Count - 1];
          }
          public List<string> GetAllGuesses()
          {
               return m_strGuess;
          }
          public List<string> GetAllResults()
          {
               return m_pinResult;
          }

     }
}
