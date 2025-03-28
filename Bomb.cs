using Raylib_cs;
public class Bomb : GameObject {



    public Bomb(int x, int y) : base(x, y) {

    }

    public override void Draw()
    {
        Raylib.DrawCircle(_posX, _posY, 10, Color.Red);
    }
    public override void ProcessActions()
    {
        throw new NotImplementedException();
    }
    public override void HandleInput()
    {
    }
    public override int GetLeftEdge()
    {
        return _posY -8;
    }
    public override int GetRightEdge()
    {
        return _posY + 8;
    }
    public override int GetTopEdge()
    {
        return _posX -8;
    }
    public override int GetBotEdge()
    {
        return _posX + 8;
    }
}