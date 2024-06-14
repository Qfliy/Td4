
using SFML.Graphics;

public class Background(Window root)
{
  public _Forest Forest {get; private set;} = new(root);
  public _Entrance Entrance {get; private set;} = new(root);

  public class _Forest : MySprite
  {
    public _Forest(Window root) : base(root, @".\sprites\forest.png")
    {
      Position = new(root.Size.X - Texture.Size.X * Scale.X, 0);
    }
  }

  public class _Entrance : MySprite
  {
    public _Entrance(Window root) : base(root, @".\sprites\entrance.png"){}
  }
}
