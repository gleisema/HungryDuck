using SplashKitSDK;

public class WhiteDuck : Duck
{
    public WhiteDuck(Window gameWindow): base(gameWindow)
    {
    }

    
    public override void LoadResources()
    {
        Image = new Bitmap("WhiteDuck", "WhiteDuck.png");
    }

    public override void Draw(Window gameWindow)
    {
        LoadResources();
        gameWindow.DrawBitmap(Image, Left, Top);
    }
}
