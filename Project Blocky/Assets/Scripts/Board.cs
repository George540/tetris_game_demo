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
    }

    public void SetTile(Piece piece)
    {
        for (int i = 0; i < piece.Cells.Length; i++)
        {
            var tilePosition = piece.Cells[i];
        }
    }
}
