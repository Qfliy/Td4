
using SFML.Graphics;
using SFML.System;

public class MySprite : Sprite
{
  protected Window root;

  public MySprite(Window root, string path) : base(new Texture(path))
  {
    this.root = root;
    Scale = new(8f, 8f);
  }

  public virtual void Update()
  {
    root.Draw(this);
  }

  public Vector2f GetSize()
  {
    return new(Scale.X * Texture.Size.X, Scale.Y * Texture.Size.Y);
  }
}
