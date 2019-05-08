using System;
using SplashKitSDK;

public abstract class Duck {
	const int SPEED = 4;

    public Vector2D _velocity { get; set;}

	// The image we use to represent the current duck
	// on the screen.
	protected Bitmap Image { get ; set; }

    public double Left { get; private set; }
    public double Top  { get; private set; }
    
    public int Width  { get { return 50; } } 
    public int Height { get { return 50; } }

	// Current game windows.
    Window _screen;

    public Duck(Window gameWindow)
    {
		_screen = gameWindow;
        LoadResources();
        Left = 0;
        Top  = 0;

		if (SplashKit.Rnd()<0.5)
		{
			Left = SplashKit.Rnd(gameWindow.Width);

			if (SplashKit.Rnd()<0.5)
			{
				Top =-Height;
			}
			else
			{
				Top = gameWindow.Height;
			}
		}
        else
        {
            Top = SplashKit.Rnd(gameWindow.Height);

            if (SplashKit.Rnd()<0.5)
            {
                Left =-Width;
            }
            else
            {
                Left = gameWindow.Width;
            }
        }

		DuckMovement();
    }

    public abstract void Draw(Window gameWindow);

    public abstract void LoadResources();

	// Update current duck's possition.
    public void Update()
    {
        Left += _velocity.X;
        Top  += _velocity.Y;
    }

	public virtual void DuckMovement()
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
        _velocity = SplashKit.VectorMultiply(dir, SPEED);
	}

	// Returns true if the user has clicked on 
	// the current duck, and false otherwise.
	public bool Clicked {
		get {
			if (SplashKit.MouseClicked(MouseButton.LeftButton))
			{
				Point2D mpos = SplashKit.MousePosition();
				var hitX = (mpos.X >= Left-5) && (mpos.X <= (Left + Width+5));
				var hitY = (mpos.Y >= Top-5)  && (mpos.Y <= (Top + Height+5));
				return hitX && hitY;
			}
            return false;
		}
	}

	// Returns true is the current duck 
	// has hit the end of the screen.
	public bool Collided  {
		get {
			return 
				Left < -Width ||
				Left > _screen.Width ||
				Top  < -Height ||
				Top  > _screen.Height;
		}
	}

}
