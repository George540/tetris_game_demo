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
        foreach (var cell in data.Cells)
        {
            Instantiate(data._cellTile, TetrominoPosition + cell, Quaternion.identity, transform);
        }
    }

    public void DropTetromino()
    {
        TetrominoPosition += Vector3Int.down * GameManager.Instance.DropDistance;
        transform.position = TetrominoPosition;
    }
}
