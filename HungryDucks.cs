using SplashKitSDK;
using System;
using System.Collections.Generic;
public class HungryDucks
{
    private Window _gameWindow;
	private int _score;
    Timer t = SplashKit.CreateTimer("Time");
    private bool _quit = false;
    private static List<Duck> _ducks;

    public HungryDucks(Window newWindow)
    {
        _gameWindow = newWindow;
		_ducks = new List<Duck>();
        SplashKit.StartTimer(t);
    }

    public bool Quit
    {
        get { return _quit; }
    }

    public void Draw()
    {
        _gameWindow.Clear(Color.CornflowerBlue);
        PrintDialog();
		foreach (var duck in _ducks)
		    duck.Draw(_gameWindow);
         GameOver();

        _gameWindow.Refresh(60);
    }

	// Creates a random duck on the screen.
    public Duck CreateRandomDuck(Window window)
    {
        if (SplashKit.Rnd() < 0.333)
        {
            return new YellowDuck(window);
        }
        else if (SplashKit.Rnd() < 0.666 && SplashKit.Rnd() > 0.333)
        {
            return new WhiteDuck(window);
        }
        else
        {
            return new BlackDuck(window);
        }
    }

	// Updates the position for each duck on the screen.
    public void Update(Window gameWindow)
    {
		foreach (var duck in _ducks)
			duck.Update();

        CheckCollisions();

        if (SplashKit.Rnd() < 0.05)
        {
            _ducks.Add(CreateRandomDuck(gameWindow));
        }
    }

	// Removes ducks that the user has clicked on and
	// ducks that has collide with the ends of the screen.
    public void CheckCollisions()
    {
        var ducksToBeRemoved = new List<Duck>();
		foreach (var duck in _ducks)
		{
			// If the duck collided with the end of the screen
			// we just remove the duck from the list.
			if (duck.Collided)
			{
				ducksToBeRemoved.Add(duck);
			}
			// If the user clicked on the duck, we have to remove
			// the duck and also increase the score.
			else if (duck.Clicked) {
				_score += 1;
				ducksToBeRemoved.Add(duck);
			}
		}

        // Clean up
		foreach (var duck in ducksToBeRemoved)
		 	_ducks.Remove(duck);
    }

    public void PrintDialog()
    {
        string scoreText = "Score: " + _score.ToString();
        string timeText = "Time: " + (SplashKit.TimerTicks(t)/1000).ToString() + " seconds";
        SplashKit.DrawText(scoreText, Color.Black,10,10);
        SplashKit.DrawText(timeText, Color.Black,10,30);
    }

    public void GameOver()
    {
        if (_score == 10)
        {
            SplashKit.ResetTimer(t);
            SplashKit.FillRectangle(Color.DarkOrange, 200, 150, 400, 300);
            SplashKit.DrawText("Congratultions!", Color.Black, 340, 250);
            SplashKit.DrawText("You caught 10 ducks.", Color.Black, 322, 300);
            SplashKit.DrawText("Your time was "+ _score.ToString()+ " seconds", Color.Black, 310, 350);

        }
    }


    public void HandleInput(Window gameWindow)
    {
        if (SplashKit.KeyDown(KeyCode.EscapeKey))
        {
            _quit = true;
            SplashKit.CloseWindow(gameWindow);
        }
    }
}
