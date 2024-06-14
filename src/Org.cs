
using SFML.Graphics;

public class Org : MySprite
{
  private const float step = 8f;

  private readonly Random random = new();

  public Org(Window root) : base(root, @".\sprites\orc.png")
  {
    Respawn();
  }

  public override void Update()
  {
    base.Update();

    Position = new(Position.X - step, Position.Y);

    if (Position.X <= 0)
      root.GameOver = true;
  }

  public void Respawn()
  {
    Position = new(root.Size.X, random.Next(0, (int)(root.Size.Y - Texture.Size.Y * Scale.Y)));
  }
}
