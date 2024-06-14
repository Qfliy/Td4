
using SFML.Graphics;
using SFML.Window;

public class Player : MySprite
{
  private const float step = 8f;
  private float way = 1f;

  public List<IceBall> Balls {get; set;} = [];

  public Player(Window root) : base(root, @".\sprites\player.png")
  {
    Position = new(64, root.Size.Y / 2 - Texture.Size.Y * Scale.Y / 2);
  }

  public override void Update()
  {
    UpdateBalls();

    base.Update();

    Position = new(Position.X, Position.Y + way * step);

    if (Position.Y > root.Size.Y - Texture.Size.Y * Scale.Y)
      way = -1;

    if (Position.Y <= 0)
      way = 1;
  }

  public void UpdateBalls()
  {
    for (int i = Balls.Count - 1; i >= 0 ; i--)
    {
      Balls[i].Update();

      if (Balls[i].HasStoped)
        Balls.RemoveAt(i);
    }
  }

  public void OnKeyPress(Keyboard.Key key)
  {
    switch (key)
    {
      case Keyboard.Key.Q:
        way = - way;
        break;
      case Keyboard.Key.W:
        if (Balls.Count < 3)
        Balls.Add(new(root, Position.Y));
        break;
    };
  }

  public class IceBall : MySprite
  {
    private const float step = 16f;

    public bool HasStoped {get; private set;} = false;

    public IceBall(Window root, float positionY) : base(root, @"sprites/ice-ball.png")
    {
      Position = new(70, positionY);
    }

    public override void Update()
    {
      base.Update();

      Position = new(Position.X + step, Position.Y);

      if (Position.X + Texture.Size.X * Scale.X > root.Size.X)
        HasStoped = true;
    }
  }
}
