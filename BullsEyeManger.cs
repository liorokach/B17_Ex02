using System;

namespace BullsEyeManger
{
     using TheGame;
     using enumGameStatus;
     using Screen;

     internal class BullsEyeManger
     {
          public static void GameLoop()
          {
               TheGame bullsEyeGame;
               bool wantToPlay = true;
               do
               {
                    bullsEyeGame = new TheGame();
                    bullsEyeGame.RunTheGame();
                    if (bullsEyeGame.getStatus() != eGameStatus.Quit)
                    {
                         wantToPlay = Screen.IsUserWantNewGame();
                    }
                    else
                    {
                         wantToPlay = false;
                    }

                    Screen.ClearScreen();
               }
               while (wantToPlay);
               Screen.EndOfGameMsg();
          }
     }
}
