using System;
using System.Collections.Generic;
using System.Text;

namespace UserChoise
{
     internal class UserChoise
     {
          private int m_currGuessNum = 0;
          private List<string> m_strGuess;
          private List<string> m_pinResult;

          public UserChoise(int i_maxNumGuess)
          {
               m_strGuess = new List<string>(i_maxNumGuess);
               m_pinResult = new List<string>(i_maxNumGuess);
               for (int i = 0; i < i_maxNumGuess; i++)
               {
                    m_strGuess.Insert(0, string.Empty);
                    m_pinResult.Insert(0, string.Empty);
               }
          }

          public void AddGuess(string i_userStrGuess)
          {
               m_strGuess.Insert(m_currGuessNum, i_userStrGuess);
               m_currGuessNum++;
          }

          public void UpdateResult(string i_guessResult)
          {
               ////reducing 1 from currGuess name bacause when we come to this function we
               ////allready added guess and we need that the guess and result will be at the same index
               m_pinResult.Insert(m_currGuessNum - 1, i_guessResult);
          }

          public string GetLastGuess()
          {
               return m_strGuess[m_strGuess.Count - 1];
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

          public void SetCurrGueessNumToZero()
          {
               m_currGuessNum = 0;
          }
     }
}
