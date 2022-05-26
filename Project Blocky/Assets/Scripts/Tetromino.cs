using UnityEngine;
using UnityEngine.Tilemaps;

public enum Tetromino
{
    I,
    O,
    T,
    J,
    L,
    S,
    Z
}

[System.Serializable]
public struct TetrominoData
{
    public Tetromino _tetromino;
    public Tile _tile;
    public Vector2Int[] Cells { get; private set; }

    public void Initialize()
    {
        Cells = Data.Cells[_tetromino];
    }
}
