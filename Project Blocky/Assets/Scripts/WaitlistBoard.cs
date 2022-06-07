using System.Collections.Generic;
using UnityEngine;

public class WaitlistBoard : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TetrominoData[] _tetrominoesData;
    [SerializeField] private TetrominoDisplay[] _tetrominoDisplays = new TetrominoDisplay[2];
    [SerializeField] private readonly Queue<TetrominoData> _waitlistTetrominoData = new();

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

    public TetrominoData GetTetrominoData(int choice)
    {
        return _tetrominoesData[choice];
    }
    
    public void AddTetrominoOnWaitingList(TetrominoData data)
    {
        _waitlistTetrominoData.Enqueue(data);
    }

    public void EraseManualWaitlist()
    {
        _waitlistTetrominoData.Clear();
    }
}
