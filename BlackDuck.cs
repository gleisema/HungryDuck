using SplashKitSDK;

public class BlackDuck: Duck
{
    public BlackDuck(Window gameWindow): base(gameWindow)
    {

    }

    public override void LoadResources()
    {
        Image = new Bitmap("BlackDuck", "BlackDuck.png");
    }

    public override void Draw(Window gameWindow)
    {
        LoadResources();
        gameWindow.DrawBitmap(Image, Left, Top);
    }


}
