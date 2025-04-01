using System.Runtime.CompilerServices;
using Raylib_cs;

    public class Player : GameObject {


        public Player(int x, int y, int screenHeight, int screenWidth) : base(x, y) {
            _rightBoundary = screenWidth - 50;
            _bottomBoundary = screenHeight - 25;
        }

        public override void Draw() {
            Raylib.DrawRectangle(_posX, _posY, 50, 25, Color.Blue);
        }
        public override void HandleInput()
        {   if (Raylib.IsKeyDown(KeyboardKey.LeftShift)) {
                if (Raylib.IsKeyDown(KeyboardKey.W)) {
                    _posY = Math.Max(_posY - 6, 0);
                }
                if (Raylib.IsKeyDown(KeyboardKey.S)) {
                    _posY = Math.Min(_posY + 6, _bottomBoundary);
                }
                if (Raylib.IsKeyDown(KeyboardKey.A)) {
                    _posX = Math.Max(_posX - 10, 0);
                }
                if (Raylib.IsKeyDown(KeyboardKey.D)) {
                    _posX = Math.Min(_posX + 10, _rightBoundary);
                }
            }
            else {
                if (Raylib.IsKeyDown(KeyboardKey.W)) {
                _posY = Math.Max(_posY - 3, 0);
                }
                if (Raylib.IsKeyDown(KeyboardKey.S)) {
                    _posY = Math.Min(_posY + 3, _bottomBoundary);
                }
                if (Raylib.IsKeyDown(KeyboardKey.A)) {
                    _posX = Math.Max(_posX - 5, 0);
                }
                if (Raylib.IsKeyDown(KeyboardKey.D)) {
                    _posX = Math.Min(_posX + 5, _rightBoundary);
                }
            }
            
        }

        public override (bool, bool) ProcessActions(List<GameObject> gameObjects) {
            return (false, false);
        }
    public override int GetLeftEdge()
    {
        return _posX;
    }
    public override int GetRightEdge()
    {
        return _posX + 50;
    }
    public override int GetTopEdge()
    {
        return _posY;
    }
    public override int GetBotEdge()
    {
        return _posY + 25;
    }
}