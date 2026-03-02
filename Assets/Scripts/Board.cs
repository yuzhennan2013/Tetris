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

    private void SpawnTetromino()
    {
        int randomIndex = UnityEngine.Random.Range(0, tetrominos.Length);
        TetrominoData data = tetrominos[randomIndex];

        activePiece.Initialize(this, spawnPosition, data);
        Set(this.activePiece);
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int worldPosition = piece.position + piece.cells[i];
            tilemap.SetTile(worldPosition, piece.data.tile);
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
}
