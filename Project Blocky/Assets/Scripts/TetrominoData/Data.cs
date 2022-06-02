using System.Collections.Generic;
using UnityEngine;

public enum TetrominoType
{
    I, J, L, O, S, T, Z
}

public static class Data
{
    public const int LeftWallBoundary = -9;
    public const int RightWallBoundary = 9;
    public const int BottomWallBoundary = -19;
    public const int gridsPerRow = (RightWallBoundary - LeftWallBoundary) / 2 + 1;
    
    public const float SlowMoveTimeDistance = 1f;
    public const float FastMoveTimeDistance = 0.05f;
    
    public static readonly Dictionary<TetrominoType, Vector2Int[]> Cells = new()
    {
        { TetrominoType.I, new[] { new Vector2Int(-2, 0), new Vector2Int( 0, 0), new Vector2Int(2, 0), new Vector2Int(4, 0) } },
        { TetrominoType.J, new[] { new Vector2Int(-2, 2), new Vector2Int(-2, 0), new Vector2Int(0, 0), new Vector2Int(2, 0) } },
        { TetrominoType.L, new[] { new Vector2Int(-2, 0), new Vector2Int(0, 0), new Vector2Int(2, 0), new Vector2Int(2, 2) } },
        { TetrominoType.O, new[] { new Vector2Int(0, 0), new Vector2Int(0, 2), new Vector2Int(2, 0), new Vector2Int(2, 2) } },
        { TetrominoType.S, new[] { new Vector2Int(-2, 0), new Vector2Int(0, 0), new Vector2Int(0, 2), new Vector2Int(2, 2) } },
        { TetrominoType.T, new[] { new Vector2Int(-2, 0), new Vector2Int(0, 0), new Vector2Int(2, 0), new Vector2Int(0, 2) } },
        { TetrominoType.Z, new[] { new Vector2Int(-2, 2), new Vector2Int( 0, 2), new Vector2Int(0, 0), new Vector2Int(2, 0) } },
    };
}
