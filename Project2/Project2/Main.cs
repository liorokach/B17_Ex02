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
               
               ComputerChoise cmp = new ComputerChoise(4);
               UserChoise.UserChoise user = new UserChoise.UserChoise(4);
               Console.WriteLine(user.GetCompChoise());
               for (int i = 0; i < 10; i++)
               {
                    user.AddGuess(Console.ReadLine());
                    string res = user.GetResult();
                    Console.WriteLine(res);
               }
          }
        
        
    }
}
