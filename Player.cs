    using Raylib_cs;

    public class Player : GameObject {



        public Player(int x, int y) : base(x, y) {

        }

        public override void Draw() {
            Raylib.DrawRectangle(_posX, _posY, 50, 25, Color.Blue);
        }
        public override void HandleInput()
        {
            if (Raylib.IsKeyDown(KeyboardKey.W)) {
                _posY = Math.Max(_posY - 3, 0);
            }
            if (Raylib.IsKeyDown(KeyboardKey.S)) {
                _posY = Math.Min(_posY + 3, 575);
            }
            if (Raylib.IsKeyDown(KeyboardKey.A)) {
                _posX = Math.Max(_posX - 5, 0);
            }
            if (Raylib.IsKeyDown(KeyboardKey.D)) {
                _posX = Math.Min(_posX + 5, 750);
            }
        }

        public override void ProcessActions() {
            
        }
    public override int GetLeftEdge()
    {
        return _posY;
    }
    public override int GetRightEdge()
    {
        return _posY + 50;
    }
    public override int GetTopEdge()
    {
        return _posX;
    }
    public override int GetBotEdge()
    {
        return _posX + 25;
    }
}