using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private RestedCells _restedCellsSystem;
    
    [SerializeField, Min(0)] private int _moveDistance;
    [SerializeField] private Vector3Int _startPosition;
    [SerializeField] private float _timerCountdown;
    [SerializeField] private Tetromino _baseTetrominoPrefab;
    [SerializeField] private TetrominoData[] _tetrominoesData;
    private Tetromino _currentTetromino;
    private float _moveTimeInterval;

    public RestedCells RestedCellsSystem => _restedCellsSystem;
    public Tetromino CurrentTetromino => _currentTetromino;
    public int MoveDistance => _moveDistance;

    private void Start()
    {
        _timerCountdown = _moveTimeInterval;
        _moveTimeInterval = Data.SlowMoveTimeDistance;
        CreateTetromino();
    }

    void CreateTetromino()
    {
        var choice = Random.Range(0, _tetrominoesData.Length);
        _currentTetromino = Instantiate(_baseTetrominoPrefab, _startPosition, Quaternion.identity);
        _currentTetromino.Initialize(this, _tetrominoesData[choice], _startPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentTetromino == null)
        {
            CreateTetromino();
        }
        ChangeMoveTimeInterval();
        UpdateTimer();
    }
    private void UpdateTimer()
    {
        if (_timerCountdown < 0)
        {
            if (_currentTetromino != null && !_currentTetromino.IsRested)
            {
                _currentTetromino.DropTetromino(_moveDistance);
            }
            _timerCountdown = _moveTimeInterval;
        }
        _timerCountdown -= Time.deltaTime;
    }

    private void ChangeMoveTimeInterval()
    {
        _moveTimeInterval = _inputSystem.IsDroppingFast ? Data.FastMoveTimeDistance : Data.SlowMoveTimeDistance;
    }
}