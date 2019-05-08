using SplashKitSDK;

public class YellowDuck: Duck
{
    public YellowDuck(Window gameWindow): base(gameWindow)
    {

    }

    public override void DuckMovement()
    {
        // Duck Point (Starting point).
        var fromPoint = new Point2D {
			X = Left,
			Y = Top
        };

        // Random Point
        var toPoint = new Point2D {
			X = SplashKit.Rnd(800),
			Y = SplashKit.Rnd(600)
        };

        // Direction of ducks
        Vector2D dir;
        dir = SplashKit.UnitVector(
				SplashKit.VectorPointToPoint(fromPoint, toPoint));

        // Set speed
        _velocity = SplashKit.VectorMultiply(dir, 10);
	}

    public override void LoadResources()
    {
        Image = new Bitmap("YellowDuck", "YellowDuck.png");
    }

    public override void Draw(Window gameWindow)
    {
        gameWindow.DrawBitmap(Image, Left, Top);
    }
}
