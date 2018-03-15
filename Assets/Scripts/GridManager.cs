using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public GameObject[] tilePrefab;
    public GameObject loadingPanel;

    public TimerForLoading timer;
    public MenuInTheGame menu;
    public Text ScoreText;
    public Text TargetText;
    public Text HighScoreText;
    private AudioSource jump;
    public static int score = 0;
    public bool begin = false;
    public int gridWidth;
    public int gridHeight;
    private GameObject[,] grid;
    //private string t = "";

    public ParticleSystem particle;

    void Awake()
    {
        CreateGrid();
    }

    // Use this for initialization
    void Start()
    {
        

        AudioSource[] audios = GetComponents<AudioSource>();
        jump = audios[0];
        //t = ScoreText.text;
        loadingPanel.SetActive(true);
        // menuButton.SetActive(false);
        menu.HideButtons();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.time <= 0)
        {
            if (score >= MenuInTheGame.t)
            {
                menu.nextLevel();
               
            }
            else
            {
                menu.gameOver();
            }
        }
        if (timer.time <= 0)
        {
            TargetText.text = ": " + MenuInTheGame.t;
            HighScoreText.text =": " +MenuInTheGame.highScore;
            ScoreText.text = ": " + score;

        }
        if (timer.time <= 0)
        {
            loadingPanel.SetActive(false);
            begin = true;
        }

        if (CanCheckForMatches())
        {
            if (CheckForMatches(true) > 0)
            {
                DropTilesDown();
                FillEmptySlots();
            }
        }
    }

    private bool CanCheckForMatches()
    {
        bool hasMoved = false;
        bool isMoving = false;
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                TileMover mvr = grid[x, y].GetComponent<TileMover>();
                isMoving |= mvr.IsMoving();
                hasMoved |= mvr.HasMoved();
            }
        }
        return !isMoving && hasMoved;
    }

    void CreateGrid()
    {
        grid = new GameObject[gridWidth, gridHeight];

        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                GameObject tile = CreateRandomTile(x, y);
                grid[x, y] = tile;
                while (CheckForMatches(false) > 0)
                {
                    DestroyImmediate(tile);
                    tile = CreateRandomTile(x, y);
                    grid[x, y] = tile;
                }
            }
        }
    }

    public bool SwitchTilesInGrid(GameObject obj1, GameObject obj2)
    {
        Vector2 obj1Pos = GetPosition(obj1);
        Vector2 obj2Pos = GetPosition(obj2);

        int obj1X = (int)obj1Pos.x;
        int obj1Y = (int)obj1Pos.y;
        int obj2X = (int)obj2Pos.x;
        int obj2Y = (int)obj2Pos.y;

        if (Mathf.Abs(obj1X - obj2X) > 1
            || Mathf.Abs(obj1Y - obj2Y) > 1
            || Mathf.Abs(obj1X - obj2X) + Mathf.Abs(obj1Y - obj2Y) > 1)
        {
            return false;
        }

        Debug.Log("Switching tiles: " + obj1 + ", " + obj2);
        grid[obj2X, obj2Y] = obj1;
        grid[obj1X, obj1Y] = obj2;
        return true;
    }

    private Vector2 GetPosition(GameObject go)
    {
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                GameObject tile = grid[x, y];
                if (tile.GetInstanceID() == go.GetInstanceID())
                {
                    return new Vector2(x, y);
                }
            }
        }
        throw new System.Exception();
    }

    internal int CheckForMatches(bool removeMatches)
    {

        // Debug.Log("Checking for matches");
        List<GameObject> matching = new List<GameObject>();
        List<GameObject> currentMatching = new List<GameObject>();
       
            // Outer loop
            for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                GameObject sourceTile = grid[x, y];
                if (sourceTile == null)
                {
                    continue;
                }

                Material currentMaterial = GetMaterial(sourceTile);

                // Inner loop horizontal
                for (int ix = x; ix >= 0; ix--)
                {
                    GameObject tile = grid[ix, y];

                    if (GetMaterial(tile) == currentMaterial)
                    {
                        currentMatching.Add(tile);
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentMatching.Count >= 3)
                {
                    foreach (GameObject matchedTile in currentMatching)
                    {
                        if (!matching.Contains(matchedTile))
                        {
                            matching.Add(matchedTile);
                        }
                    }
                }

                if (removeMatches)
                    CalculateScore(currentMatching);
                currentMatching.Clear();

                // Inner loop vertical
                for (int iy = y; iy >= 0; iy--)
                {
                    GameObject tile = grid[x, iy];
                    // Debug.Log(currentMaterial + "   " + GetMaterial(tile));

                    if (GetMaterial(tile) == currentMaterial)
                    {
                        currentMatching.Add(tile);
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentMatching.Count >= 3)
                {
                    foreach (GameObject matchedTile in currentMatching)
                    {
                        if (!matching.Contains(matchedTile))
                        {
                            matching.Add(matchedTile);
                        }
                    }
                }
                if (removeMatches)
                    CalculateScore(currentMatching);
                currentMatching.Clear();

            }

        }
        if (removeMatches)
        {
            // Remove matches
            for (int i = 0; i < matching.Count; i++)
            {
                GameObject tile = matching[i];
                particle.transform.position = tile.transform.position;
                particle.Emit(10);
                DestroyImmediate(tile);
            }
        }
    
        return matching.Count;
       
       
    }
        
    private Material GetMaterial(GameObject go)
    {
        return go.GetComponent<Renderer>().sharedMaterial;
    }

    private void CalculateScore(List<GameObject> currentMatching)
    {
        if (begin == true)
        {
            if (currentMatching.Count >= 3)
            {
                //   Debug.Log("-->>" + Sound.GetOn());
                if (Sound.GetOn() == true)
                    jump.Play();
                if (currentMatching.Count == 3)
                    score += 10;
                if (currentMatching.Count == 4)
                    score += 20;
                if (currentMatching.Count >= 5)
                    score += 40;
            }
        }
    }

    private void DropTilesDown()
    {
        Debug.Log("Dropping tiles down");
        int tilesMoved = 0;
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            int offset = 0;
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                GameObject tile = grid[x, y];
                if (tile == null)
                {
                    offset++;
                }
                else if (offset != 0)
                {
                    grid[x, y] = null;
                    grid[x, y - offset] = tile;
                    Vector3 pos = tile.transform.position;
                    pos.y = pos.y - offset;
                    //tile.transform.position = pos;
                    tile.GetComponent<TileMover>().MoveTo(pos);
                    tilesMoved++;
                }
            }
        }
    }

    private void FillEmptySlots()
    {
        int[] newTilesNeededCount = new int[gridWidth];
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = gridHeight - 1; y >= 0; y--)
            {
                if (grid[x, y] == null)
                {
                    newTilesNeededCount[x] += 1;
                    continue;
                }
                break;
            }
        }

        Debug.Log("Filling empty slots");
        for (int y = gridHeight - 1; y >= 0; y--)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                if (grid[x, y] == null)
                {
                    GameObject tile = CreateRandomTile(x, y);
                    grid[x, y] = tile;
                    Vector3 targetPosition = tile.transform.position;
                    // Debug.Log("targetPosition: " + targetPosition);
                    tile.transform.position = tile.transform.position + new Vector3(0, 2 + y, 0);
                    // Debug.Log("new position: " + tile.transform.position);
                    tile.GetComponent<TileMover>().MoveTo(targetPosition);
                }
            }
        }
    }

    private GameObject CreateRandomTile(int x, int y)
    {
        int random = Random.Range(0, tilePrefab.Length);
        GameObject tile = tilePrefab[random];
        GameObject go = Instantiate(tile, new Vector3(x - gridWidth / 2 + 0.5f, y - gridHeight / 2 + 0.5f, 0), tile.transform.rotation) as GameObject;
        return go;
    }
}
