

using SFML.Graphics;
using SFML.System;
using SFML.Window;


public class RestartButton : MySprite
{
  public RestartButton(Window root) : base(root, @".\sprites\restart-button.png")
  {
    Vector2f size = GetSize() / 2f;
    Vector2f position = (Vector2f)root.Size / 2f;
    Position = position - size;
  }

  public override void Update()
  {
    base.Update();
  }

  public void OnKeyPress(Keyboard.Key key) {
    if (key != Keyboard.Key.R) return;

    root.GameOver = false;
    root.HasRestarted = true;
  }
}
