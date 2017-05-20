using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    struct ComputerChoise
    {
        private string m_compChoise;

        ComputerChoise(int i_numberOfLetters)
        {
            m_compChoise = generateRndStr(i_numberOfLetters);
        }
        public static string generateRndStr(int i_numberOfLetters)
        {
            string randomStr = "";
            Random random = new Random();
            char letter;
            for (int i = 0; i < i_numberOfLetters; i++)
            {
                int offset;
                do
                {
                    offset = random.Next();
                    letter = (char)('A' + offset);
                }
                while (randomStr.Contains(letter.ToString()));
                randomStr.Insert(i,letter.ToString());
            }
            
            return randomStr;
        }
        public string CheckUserChoise(string i_userChoise)
        {
            int indexResult;
            string scoreStr = "";
            for (int i = 0; i < i_userChoise.Length; i++) 
            {
                indexResult = m_compChoise.IndexOf(i_userChoise[i]);
                if(indexResult == i)
                {
                    scoreStr.Insert(0, "V");
                }
                else if (indexResult != -1)
                {
                    scoreStr.Insert(scoreStr.Length, "X");
                }
            }
            return scoreStr;
        }
    }
}
