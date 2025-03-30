using Raylib_cs;

class GameManager
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 600;
    private Random _rand = new Random();
    private string _title;
    private List<GameObject> _gameObjects = new List<GameObject>();
    private float _spawnTimer = 0f;
    private float _spawnInterval = 2f;
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
            GameObject item = _gameObjects[i];
            if (item.ProcessActions(_gameObjects)) {
                 _gameObjects.RemoveAt(i);
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
    }
private void SpawnRandomObject()
    {
        
        int randomX = _rand.Next(20, SCREEN_WIDTH - 20); 
        Console.WriteLine($"RandomX is: {randomX}");
        int y = 0;
        if (_rand.NextDouble() > 0.5)
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
    float minInterval = 1f; 
    float maxInterval = 5f;
    
    return (float)(_rand.NextDouble() * (maxInterval - minInterval) + minInterval);
}
}