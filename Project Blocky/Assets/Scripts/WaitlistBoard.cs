using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaitlistBoard : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TetrominoData[] _tetrominoesData;
    [SerializeField] private TetrominoDisplay[] _tetrominoDisplays = new TetrominoDisplay[2];
    private Queue<TetrominoData> _waitlistTetrominoData = new Queue<TetrominoData>();

    private void Awake()
    {
        if (_waitlistTetrominoData.Count == 0)
        {
            foreach (var display in _tetrominoDisplays)
            {
                var choice = Random.Range(0, _tetrominoesData.Length);
                display.Initialize(_gameManager, _tetrominoesData[choice]);
            }
        }
    }
}
