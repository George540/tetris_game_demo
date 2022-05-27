using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField, Min(0)] private int _moveDistance;
    [SerializeField] private Vector3Int _startPosition;
    [SerializeField] private float _timerCountdown;
    [SerializeField] private Tetromino _baseTetrominoPrefab;
    [SerializeField] private TetrominoData[] _tetrominoesData;
    private Tetromino _currentTetromino;
    private float _moveTimeInterval;

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
        _currentTetromino.Initialize(_tetrominoesData[choice], _startPosition);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMoveTimeInterval();
        UpdateTimer();
    }
    private void UpdateTimer()
    {
        if (_timerCountdown < 0)
        {
            _currentTetromino.DropTetromino(_moveDistance);
            _timerCountdown = _moveTimeInterval;
        }
        _timerCountdown -= Time.deltaTime;
    }

    private void ChangeMoveTimeInterval()
    {
        _moveTimeInterval = _inputSystem.IsDroppingFast ? Data.FastMoveTimeDistance : Data.SlowMoveTimeDistance;
    }
}