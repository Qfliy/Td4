
using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class Window : RenderWindow
{
  public readonly Color BAKCGROUND_COLOR = new(185, 216, 80);

  public bool GameOver { set; private get; } = false;
  public bool HasRestarted { set; private get; } = false;

  private RestartButton button;
  private Player player;
  private Org org;
  private Background background;

  public Window() : base(new VideoMode(800, 600), "Title")
  {
    player = new(this);
    org = new(this);
    background = new(this);
    button = new(this);

    KeyPressed += (_, key) =>
    {
      player.OnKeyPress(key.Code);
      button.OnKeyPress(key.Code);
    };
    Closed += (_, _) => Close();
    Resized += (_, _) => { Size = new(800, 600); };
  }

  public void MainLoop()
  {
    while (IsOpen)
    {
      DispatchEvents();
      Clear(BAKCGROUND_COLOR);
      Update();
      Display();
      Thread.Sleep(20);
    }
  }

  public void Update()
  {
    if (HasRestarted)
    {
      org.Respawn();
      player.Balls = [];
      HasRestarted = false;
    }
    else if (GameOver)
    {
      button.Update();
      return;
    }

    background.Entrance.Update();
    Colision();
    org.Update();
    player.Update();
    background.Forest.Update();
  }

  public void Colision()
  {
    Vector2f size;

    foreach (var item in player.Balls)
    {
      size = item.GetSize();

      if (org.Position.X <= item.Position.X + size.X * 0.7 &&
        org.Position.Y + org.GetSize().Y >= item.Position.Y &&
        org.Position.Y * 1.1 <= item.Position.Y + size.Y
      )
      {
        org.Respawn();
      }
    }
  }
}
