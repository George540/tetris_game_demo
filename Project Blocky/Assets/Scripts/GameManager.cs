using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private RestedCells _restedCellsSystem;
    [SerializeField] private WaitlistBoard _waitlistBoard;
    
    [SerializeField, Min(0)] private int _moveDistance;
    [SerializeField] private Vector3Int _startPosition;
    [SerializeField] private float _timerCountdown;
    [SerializeField] private Tetromino _activeTetromino;
    private float _moveTimeInterval;

    public RestedCells RestedCellsSystem => _restedCellsSystem;
    public Tetromino ActiveTetromino => _activeTetromino;
    public int MoveDistance => _moveDistance;

    private void Start()
    {
        _timerCountdown = _moveTimeInterval;
        _moveTimeInterval = Data.SlowMoveTimeDistance;
    }

    public TetrominoData GetNextTetromino()
    {
        return _waitlistBoard.GetNextTetromino();
    }
    
    public void CreateTetromino(TetrominoData _data)
    {
        var tetrominoTransform = _activeTetromino.transform;
        tetrominoTransform.position = _startPosition;
        tetrominoTransform.rotation = Quaternion.identity;
        _activeTetromino.Initialize(this, _data, _startPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (_activeTetromino == null) return;
        
        ChangeMoveTimeInterval();
        UpdateTimer();
    }
    private void UpdateTimer()
    {
        if (_timerCountdown < 0)
        {
            if (_activeTetromino != null && !_activeTetromino.IsRested)
            {
                _activeTetromino.DropTetromino(_moveDistance);
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