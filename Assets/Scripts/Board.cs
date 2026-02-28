using System;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Board : MonoBehaviour
{
    public TetrominoData[] tetrominos;
    public Piece activePiece { get; private set; }
    public Tilemap tilemap { get; private set; }
    public Vector3Int spawnPosition;

    private void Awake()
    {
        this.tilemap = GetComponentInChildren<Tilemap>();
        this.activePiece = GetComponentInChildren<Piece>();
        foreach (var data in tetrominos)
        {
            data.Initialize();
        }
    }

    private void Start()
    {
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
        foreach (Vector3Int cell in piece.cells)
        {
            Vector3Int worldPosition = piece.position + cell;
            tilemap.SetTile(worldPosition, piece.data.tile);
        }
    }
}
