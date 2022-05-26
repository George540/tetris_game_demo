using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static readonly float cos = Mathf.Cos(Mathf.PI / 2f);
    public static readonly float sin = Mathf.Sin(Mathf.PI / 2f);
    public static readonly float[] RotationMatrix = { cos, sin, -sin, cos };

    public static readonly Dictionary<Tetromino, Vector2Int[]> Cells = new()
    {
        { Tetromino.I, new[] { new Vector2Int(-1, 1), new Vector2Int( 0, 1), new Vector2Int( 1, 1), new Vector2Int( 2, 1) } },
        { Tetromino.J, new[] { new Vector2Int(-1, 1), new Vector2Int(-1, 0), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        { Tetromino.L, new[] { new Vector2Int( 1, 1), new Vector2Int(-1, 0), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        { Tetromino.O, new[] { new Vector2Int( 0, 1), new Vector2Int( 1, 1), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        { Tetromino.S, new[] { new Vector2Int( 0, 1), new Vector2Int( 1, 1), new Vector2Int(-1, 0), new Vector2Int( 0, 0) } },
        { Tetromino.T, new[] { new Vector2Int( 0, 1), new Vector2Int(-1, 0), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        { Tetromino.Z, new[] { new Vector2Int(-1, 1), new Vector2Int( 0, 1), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
    };

    private static readonly Vector2Int[,] WallKicksI = {
        { new(0, 0), new(-2, 0), new( 1, 0), new(-2,-1), new( 1, 2) },
        { new(0, 0), new( 2, 0), new(-1, 0), new( 2, 1), new(-1,-2) },
        { new(0, 0), new(-1, 0), new( 2, 0), new(-1, 2), new( 2,-1) },
        { new(0, 0), new( 1, 0), new(-2, 0), new( 1,-2), new(-2, 1) },
        { new(0, 0), new( 2, 0), new(-1, 0), new( 2, 1), new(-1,-2) },
        { new(0, 0), new(-2, 0), new( 1, 0), new(-2,-1), new( 1, 2) },
        { new(0, 0), new( 1, 0), new(-2, 0), new( 1,-2), new(-2, 1) },
        { new(0, 0), new(-1, 0), new( 2, 0), new(-1, 2), new( 2,-1) },
    };

    private static readonly Vector2Int[,] WallKicksJLOSTZ = {
        { new(0, 0), new(-1, 0), new(-1, 1), new(0,-2), new(-1,-2) },
        { new(0, 0), new( 1, 0), new( 1,-1), new(0, 2), new( 1, 2) },
        { new(0, 0), new( 1, 0), new( 1,-1), new(0, 2), new( 1, 2) },
        { new(0, 0), new(-1, 0), new(-1, 1), new(0,-2), new(-1,-2) },
        { new(0, 0), new( 1, 0), new( 1, 1), new(0,-2), new( 1,-2) },
        { new(0, 0), new(-1, 0), new(-1,-1), new(0, 2), new(-1, 2) },
        { new(0, 0), new(-1, 0), new(-1,-1), new(0, 2), new(-1, 2) },
        { new(0, 0), new( 1, 0), new( 1, 1), new(0,-2), new( 1,-2) },
    };

    public static readonly Dictionary<Tetromino, Vector2Int[,]> WallKicks = new()
    {
        { Tetromino.I, WallKicksI },
        { Tetromino.J, WallKicksJLOSTZ },
        { Tetromino.L, WallKicksJLOSTZ },
        { Tetromino.O, WallKicksJLOSTZ },
        { Tetromino.S, WallKicksJLOSTZ },
        { Tetromino.T, WallKicksJLOSTZ },
        { Tetromino.Z, WallKicksJLOSTZ },
    };

}
