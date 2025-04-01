public abstract class GameObject {
    protected int _posX;
    protected int _posY;
    protected int speed;
    protected int _rightBoundary;
protected int _bottomBoundary;
    protected Random _rand = new Random();

    public GameObject(int x, int y) {
        _posX = x;
        _posY = y;
    }

    public abstract void Draw();
    public abstract (bool, bool) ProcessActions(List<GameObject> gameObjects);
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
    public bool CheckCollision(GameObject other)
    {
        return this.GetRightEdge() >= other.GetLeftEdge() &&
       this.GetLeftEdge() <= other.GetRightEdge() &&
       this.GetBotEdge() >= other.GetTopEdge() &&
       this.GetTopEdge() <= other.GetBotEdge();
    }

}