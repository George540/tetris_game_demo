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

    [SerializeField, Min(0)] private int _moveDistance;
    [SerializeField] private Vector3Int _startPosition;
    [SerializeField] private float _moveTimeInterval;
    [SerializeField] private float _timerCountdown;
    [SerializeField] private Tetromino _baseTetrominoPrefab;
    [SerializeField] private TetrominoData[] _tetrominoesData;
    private Tetromino _currentTetromino;

    public Tetromino CurrentTetromino => _currentTetromino;
    public int MoveDistance => _moveDistance;

    private void Start()
    {
        _timerCountdown = _moveTimeInterval;
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
}