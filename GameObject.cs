using System.Security.Cryptography.X509Certificates;

public abstract class GameObject {
    protected int _posX;
    protected int _posY;

    public GameObject(int x, int y) {
        _posX = x;
        _posY = y;
    }

    public abstract void Draw();
    public abstract void ProcessActions();
    public abstract void HandleInput();
    public virtual int GetLeftEdge() {
        return 10;
    }
    public virtual int GetRightEdge() {
        return 10;
    }

    public virtual int GetTopEdge() {
        return 10;
    }
    public virtual int GetBotEdge() {
        return 10;
    }
}