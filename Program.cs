using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window newWindow = new Window("Hungry Ducks", 800, 600);
        HungryDucks newGame = new HungryDucks(newWindow);

        while ((!newWindow.CloseRequested) && (!newGame.Quit))
        {
            SplashKit.ProcessEvents();
            newGame.HandleInput(newWindow);
            newGame.Update(newWindow);
            newGame.Draw();
        }
    }
}
