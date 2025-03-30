using Raylib_cs;
public class Bomb : GameObject {

    

    public Bomb(int x, int y, int screenHeight) : base(x, y) {
        speed = _rand.Next(1, 6);
        _bottomBoundary = screenHeight;

    }

    public override void Draw()
    {
        Raylib.DrawCircle(_posX, _posY, 10, Color.Red);
    }
    public override bool ProcessActions(List<GameObject> gameObjects)
    {
        _posY =_posY + speed;
        foreach (GameObject obj in gameObjects)
        {
            if (obj is Player player && CheckCollision(player))
            {
                return true;
            }
            if (_posY - 10 >= _bottomBoundary) {
                return true;
            }
        }
        return false;
    }
    public override void HandleInput()
    {
    }
    public override int GetLeftEdge()
    {
        return _posX - 8;
    }
    public override int GetRightEdge()
    {
        return _posX + 8;
    }
    public override int GetTopEdge()
    {
        return _posY - 8;
    }
    public override int GetBotEdge()
    {
        return _posY + 8;
    }
    
}