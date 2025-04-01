using Raylib_cs;

class GameManager
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 600;
    private Random _rand = new Random();
    private string _title;
    private List<GameObject> _gameObjects = new List<GameObject>();
    private float _diffScalar = 0f;
    private float _spawnTimer = 0f;
    private float _spawnInterval = 1f;
    private int _score;
    private int _lives = 3;
    private bool _defeat;
    public GameManager()
    {
        _title = "CSE 210 Game";

    }

    /// <summary>
    /// The overall loop that csontrols the game. It calls functions to
    /// handle interactions, update game elements, and draw the screen.
    /// </summary>
    public void Run()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, _title);
        // If using sound, un-comment the lines to init and close the audio device
        // Raylib.InitAudioDevice();

        InitializeGame();

        while (!Raylib.WindowShouldClose())
        {
            HandleInput();
            ProcessActions();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            DrawElements();

            Raylib.EndDrawing();
        }

        // Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }

    /// <summary>
    /// Sets up the initial conditions for the game.
    /// </summary>
    private void InitializeGame()
    {
        Player player = new Player(300,500,SCREEN_HEIGHT,SCREEN_WIDTH);
        _gameObjects.Add(player);
    }

    /// <summary>
    /// Responds to any input from the user.
    /// </summary>
    private void HandleInput()
    {
        foreach (GameObject item in _gameObjects)
        {
            item.HandleInput();
        }

    }

    /// <summary>
    /// Processes any actions such as moving objects or handling collisions.
    /// </summary>
    private void ProcessActions()
    {
        for (int i = _gameObjects.Count -1; i >= 0; i--)
        {
            if (_defeat) {
                Raylib.DrawText("Game Over", 300, 300, 30, Color.Red);
            }
            GameObject item = _gameObjects[i];
            var (isCollide,isDead) = item.ProcessActions(_gameObjects);
            if (isCollide && isDead)   {
                if (item is Bomb) {
                    _lives --;
                }
                if (item is Gem)
                    _score ++;
                _gameObjects.RemoveAt(i);
            }
            else if (isDead) {
                _gameObjects.RemoveAt(i);
            }
            if (_lives == 0 && item is Player) {
            _gameObjects.RemoveAt(i);
            _defeat = true;
         }
        }
         _spawnTimer += Raylib.GetFrameTime();
        if (_spawnTimer >= _spawnInterval)
        {
            SpawnRandomObject();
            _spawnTimer = 0f;
        }
         _spawnInterval = GenerateRandomInterval();
         
    }


    /// <summary>
    /// Draws all elements on the screen.
    /// </summary>
    private void DrawElements()
    {
        foreach (GameObject entity in _gameObjects) {
            entity.Draw();
        }
        Raylib.DrawText($"Score: {_score}", 10, 10, 32, Color.Black);
        Raylib.DrawText($"Lives: {_lives}", SCREEN_WIDTH - 150, 10, 32, Color.Black);
    }
private void SpawnRandomObject()
    {
        
        int randomX = _rand.Next(20, SCREEN_WIDTH - 20);    
        Console.WriteLine($"RandomX is: {randomX}");
        int y = 0;
        if (_rand.NextDouble() > 0.4)
        {
            Bomb bomb = new Bomb(randomX, y, SCREEN_HEIGHT);
            _gameObjects.Add(bomb);
        }
        else
        {
            Gem gem = new Gem(randomX, y, SCREEN_HEIGHT);
            _gameObjects.Add(gem);
        }

        Console.WriteLine("Spawned a new object!");
    }
    private float GenerateRandomInterval()
{
    _diffScalar += Raylib.GetFrameTime()/25;
    float minInterval = 1f; 
    float maxInterval = Math.Max(6f - _diffScalar, 0.5f);
    Console.WriteLine($"Scalar: {_diffScalar}");
    
    return (float)(_rand.NextDouble() * (maxInterval - minInterval) + minInterval);
}
}