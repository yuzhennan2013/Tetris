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
        for (int i = 0; i < tetrominos.Length; i++) {
            tetrominos[i].Initialize();
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
        for (int i = 0; i < piece.cells.Length; i++) 
        {
            Vector3Int worldPosition = piece.position + piece.cells[i];
            tilemap.SetTile(worldPosition, piece.data.tile);
        }
    }
}
