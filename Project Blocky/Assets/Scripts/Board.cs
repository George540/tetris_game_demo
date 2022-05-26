using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    private static Board _instance;

    public static Board Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Board>();
            }

            return _instance;
        }
    }
    
    public Tilemap _tilemap;
    public TetrominoData[] _tetrominoes;
    [SerializeField] private Piece _currentPiece;
    [SerializeField] private Vector3Int _spawnPosition;

    private void Awake()
    {
        InitializeTetrominoes();
    }

    private void Start()
    {
        SpawnPiece();
    }

    private void InitializeTetrominoes()
    {
        foreach (var tetromino in _tetrominoes)
        {
            tetromino.Initialize();
        }
    }

    public void SpawnPiece()
    {
        var random = Random.Range(0, _tetrominoes.Length);
        var data = _tetrominoes[random];
        
        _currentPiece.Initialize(_spawnPosition, data);
        SetTile(_currentPiece);
    }

    public void SetTile(Piece piece)
    {
        foreach (var cell in piece.Cells)
        {
            var tilePosition = cell + piece.Position;
            _tilemap.SetTile(tilePosition, piece.Data._tile);
        }
    }
}
