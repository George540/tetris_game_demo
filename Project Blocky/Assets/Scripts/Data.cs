using System.Collections.Generic;
using UnityEngine;

public enum TetrominoType
{
    I, J, L, O, S, T, Z
}

public static class Data
{
    public static readonly Dictionary<TetrominoType, Vector2Int[]> Cells = new()
    {
        { TetrominoType.I, new[] { new Vector2Int(-2, 0), new Vector2Int( 0, 0), new Vector2Int( 2, 0), new Vector2Int( 4, 0) } },
        { TetrominoType.J, new[] { new Vector2Int(-1, 1), new Vector2Int(-1, 0), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        { TetrominoType.L, new[] { new Vector2Int( 1, 1), new Vector2Int(-1, 0), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        { TetrominoType.O, new[] { new Vector2Int( 0, 1), new Vector2Int( 1, 1), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        { TetrominoType.S, new[] { new Vector2Int( 0, 1), new Vector2Int( 1, 1), new Vector2Int(-1, 0), new Vector2Int( 0, 0) } },
        { TetrominoType.T, new[] { new Vector2Int( 0, 1), new Vector2Int(-1, 0), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        { TetrominoType.Z, new[] { new Vector2Int(-1, 1), new Vector2Int( 0, 1), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
    };
}
