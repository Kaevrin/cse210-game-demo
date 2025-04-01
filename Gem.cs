 using Raylib_cs;
public class Gem : GameObject {



    public Gem(int x, int y, int screenHeight) : base(x, y) {
        speed = _rand.Next(3, 10);
        _bottomBoundary = screenHeight;
    }

    public override void Draw() {
        Raylib.DrawRectangle(_posX, _posY, 20, 20, Color.Green);
    }
    public override (bool, bool) ProcessActions(List<GameObject> gameObjects)
    {
        _posY =_posY + speed;
        foreach (GameObject obj in gameObjects)
        {
            if (obj is Player player && CheckCollision(player))
            {
                return (true, true);
            }
            if (_posY - 10 >= _bottomBoundary) {
                return (true, false);
            }
        }
        return (false, false);
    }
    public override void HandleInput()
    {
    }
    public override int GetLeftEdge()
    {
        return _posX;
    }
    public override int GetRightEdge()
    {
        return _posX + 20;
    }
    public override int GetTopEdge()
    {
        return _posY;
    }
    public override int GetBotEdge()
    {
        return _posY + 20;
    }

}