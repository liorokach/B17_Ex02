using System;
using UserChoise;
using System.Collections.Generic;
using System.Text;
namespace ComputerChoise
{
    class Ex02
    {
        public static void Main()
        {
               GameBoard.GameBoard b = new GameBoard.GameBoard(9, 9 , 7);
               b.PrintLineInBoard(0);
               b.PrintLineInBoard(1);
               ComputerChoise cmp = new ComputerChoise(4);
               UserChoise.UserChoise user = new UserChoise.UserChoise(4);
               user.AddGuess("A B C D");
               b.UpdateBoard(user.GetLastGuess(),(cmp.CheckUserChoise(user.GetLastGuess())));
               b.PrintLineInBoard(2);


          }
        
        
    }
}
