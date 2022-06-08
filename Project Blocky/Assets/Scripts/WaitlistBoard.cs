using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaitlistBoard : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TetrominoData[] _tetrominoesData;
    [SerializeField] private TetrominoDisplay[] _tetrominoDisplays = new TetrominoDisplay[2];
    [SerializeField] private List<TetrominoData> _displayData = new();
    private readonly Queue<TetrominoData> _waitlistTetrominoData = new();
    
    private void Awake()
    {
        InitializeTetromino();
    }

    private void InitializeTetromino()
    {
        foreach (var display in _tetrominoDisplays)
        {
            Debug.Log(_waitlistTetrominoData.Count);
            if (_waitlistTetrominoData.Count > 0)
            {
                display.Initialize(_gameManager, GetFirstTetrominoData());
            }
            else
            {
                var choice = Random.Range(0, _tetrominoesData.Length);
                display.Initialize(_gameManager, _tetrominoesData[choice]);
            }
        }
        
        var firstChoice = Random.Range(0, _tetrominoesData.Length);
        _gameManager.CreateTetromino(_tetrominoesData[firstChoice]);
    }
    
    public TetrominoData GetNextTetromino()
    {
        var nextTetromino = _tetrominoDisplays[0].RemoveData();

        _tetrominoDisplays[0].Initialize(_gameManager, _tetrominoDisplays[1].RemoveData());
        if (_waitlistTetrominoData.Count > 0)
        {
            _tetrominoDisplays[1].Initialize(_gameManager, GetFirstTetrominoData());
        }
        else
        {
            var choice = Random.Range(0, _tetrominoesData.Length);
            _tetrominoDisplays[1].Initialize(_gameManager, _tetrominoesData[choice]);
        }

        return nextTetromino;
    }

    [ExecuteAlways]
    public TetrominoData GetTetrominoData(int choice)
    {
        return _tetrominoesData[choice];
    }
    
    [ExecuteAlways]
    public void AddTetrominoOnWaitingList(TetrominoData data)
    {
        _waitlistTetrominoData.Enqueue(data);
        _displayData.Add(data);
    }
    
    private TetrominoData GetFirstTetrominoData()
    {
        _displayData.RemoveAt(0);
        return _waitlistTetrominoData.Dequeue();
    }

    [ExecuteAlways]
    public void EraseManualWaitlist()
    {
        _waitlistTetrominoData.Clear();
        _displayData.Clear();
    }
    
    private void OnApplicationQuit()
    {
        EraseManualWaitlist();
    }
}
