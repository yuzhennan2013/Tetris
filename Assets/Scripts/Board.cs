using System;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Board : MonoBehaviour
{
    public TetrominoData[] tetrominos;
    public Piece activePiece { get; private set; }
    public Tilemap tilemap { get; private set; }
    public Vector3Int spawnPosition;
    public Vector2Int boardSize = new Vector2Int(10, 20);

    public RectInt Bounds
    {
        get
        {
            Vector2Int position = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2);
            return new RectInt(position, boardSize);
        }
    }

    private void Awake()
    {
        Debug.Log("Awake");
        this.tilemap = GetComponentInChildren<Tilemap>();
        this.activePiece = GetComponentInChildren<Piece>();
        for (int i = 0; i < tetrominos.Length; i++) {
            tetrominos[i].Initialize();
        }
    }

    private void Start()
    {
        Debug.Log("Start");
        SpawnTetromino();
    }

    public void SpawnTetromino()
    {
        int randomIndex = UnityEngine.Random.Range(0, tetrominos.Length);
        TetrominoData data = tetrominos[randomIndex];

        activePiece.Initialize(this, spawnPosition, data);
        if (IsValidPosition(activePiece, spawnPosition))
        {
            Set(this.activePiece);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        this.tilemap.ClearAllTiles();
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int worldPosition = piece.position + piece.cells[i];
            tilemap.SetTile(worldPosition, piece.data.tile);
        }
    }

    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int worldPosition = piece.position + piece.cells[i];
            tilemap.SetTile(worldPosition, null);
        }
    }

    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        RectInt bounds = Bounds;
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int worldPosition = position + piece.cells[i];
            if (tilemap.HasTile(worldPosition) || !bounds.Contains((Vector2Int)worldPosition))
            {
                return false;
            }
        }
        return true;
    }

    public void ClearLines()
    {
        RectInt bounds = Bounds;
        for (int y = bounds.yMin; y < bounds.yMax; y++)
        {
            if (IsLineFull(y))
            {
                ClearLine(y);
                ShiftLinesDown(y + 1);
                y--;
            }
        }
    }

    private void ShiftLinesDown(int v)
    {
        RectInt bounds = Bounds;
        for (int y = v; y < bounds.yMax; y++)
        {
            for (int x = bounds.xMin; x < bounds.xMax; x++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(position);
                tilemap.SetTile(position, null);
                if (tile != null)
                {
                    tilemap.SetTile(new Vector3Int(x, y - 1, 0), tile);
                }
            }
        }
    }

    private void ClearLine(int y)
    {
        RectInt bounds = Bounds;
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            tilemap.SetTile(new Vector3Int(x, y, 0), null);
        }
    }

    private bool IsLineFull(int y)
    {
        RectInt bounds = Bounds;
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            if (!tilemap.HasTile(new Vector3Int(x, y, 0)))
            {
                return false;
            }
        }
        return true;
    }
}
