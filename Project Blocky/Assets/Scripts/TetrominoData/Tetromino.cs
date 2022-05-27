using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3Int TetrominoPosition { get; set; }
    public TetrominoData _data;

    public void Initialize(TetrominoData data, Vector3Int startPos)
    {
        _data = data;
        foreach (var cell in data._cells)
        {
            var go = Instantiate(data._cellTile, TetrominoPosition, Quaternion.identity, transform);
            go.transform.localPosition = cell;
        }

        TetrominoPosition = startPos;
    }

    public void DropTetromino(int dropDistance)
    {
        TetrominoPosition += Vector3Int.down * dropDistance;
        UpdateTransform();
    }

    public void MoveRight(int moveDistance)
    {
        TetrominoPosition += Vector3Int.right * moveDistance;
        UpdateTransform();
    }

    public void MoveLeft(int moveDistance)
    {
        TetrominoPosition += Vector3Int.left * moveDistance;
        UpdateTransform();
    }

    private void UpdateTransform()
    {
        transform.position = TetrominoPosition;
        ;
    }
}
