using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3Int TetrominoPosition { get; set; }
    public TetrominoData _data;

    public void Initialize(TetrominoData data)
    {
        _data = data;
        foreach (var cell in data._cells)
        {
            var go = Instantiate(data._cellTile, TetrominoPosition, Quaternion.identity, transform);
            go.transform.localPosition = cell;
        }
    }

    public void DropTetromino()
    {
        TetrominoPosition += Vector3Int.down * GameManager.Instance.DropDistance;
        transform.position = TetrominoPosition;
    }
}
