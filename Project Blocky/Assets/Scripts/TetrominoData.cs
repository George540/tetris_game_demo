using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TetrominoData", menuName = "ScriptableObjects/TetrominoData", order = 1)]
public class TetrominoData : ScriptableObject
{
    public TetrominoType _tetrominoType;
    public GameObject _cellTile;
    public Vector3Int[] Cells { get; private set; }

    private void OnEnable()
    {
        Cells = new Vector3Int[Data.Cells.Count];
        for (var i = 0; i < Data.Cells[_tetrominoType].Length; i++)
        {
            Cells[i] = (Vector3Int) Data.Cells[_tetrominoType][i];
        }
    }

    private void OnDisable()
    {
        Cells = null;
    }
}