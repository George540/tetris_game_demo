using System.Linq;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private GameManager _gameManager;
    
    // Start is called before the first frame update
    public Vector3Int TetrominoPosition { get; set; }
    public TetrominoData _data;
    private Transform[] _cellTransforms;
    private bool _isRested;
    public bool IsRested => _isRested;

    public void Initialize(GameManager manager, TetrominoData data, Vector3Int startPos)
    {
        _gameManager = manager;
        _data = data;
        _cellTransforms ??= new Transform[_data._cells.Length];
        for (var i = 0; i < data._cells.Length; i++)
        {
            var go = Instantiate(data._cellTile, TetrominoPosition, Quaternion.identity, transform);
            go.transform.localPosition = data._cells[i];
            _cellTransforms[i] = go.transform;
        }

        TetrominoPosition = startPos;
    }

    public void DropTetromino(int dropDistance)
    {
        if (_cellTransforms.ToList().Any(c => c.position.y <= Data.BottomWallBoundary))
        {
            RestTetromino();
            return;
        }
        
        foreach (var cell in _cellTransforms)
        {
            if (_gameManager.RestedCellsSystem.RestedCellsCollection[(int) cell.position.x].Count > 0 &&
                _gameManager.RestedCellsSystem.RestedCellsCollection[(int) cell.position.x].Last().position.y + 2 >= cell.position.y)
            {
                RestTetromino();
                return;
            }
        }
        
        TetrominoPosition += Vector3Int.down * dropDistance;
        UpdateTransform();
    }

    public void MoveRight(int moveDistance)
    {
        if (_cellTransforms.ToList().Any(c => c.position.x >= Data.RightWallBoundary)) return;
        
        TetrominoPosition += Vector3Int.right * moveDistance;
        UpdateTransform();
    }

    public void MoveLeft(int moveDistance)
    {
        if (_cellTransforms.ToList().Any(c => c.position.x <= Data.LeftWallBoundary)) return;
        
        TetrominoPosition += Vector3Int.left * moveDistance;
        UpdateTransform();
    }

    private void RestTetromino()
    {
        foreach (var cell in _cellTransforms)
        {
            cell.parent = _gameManager.RestedCellsSystem.transform;
            _gameManager.RestedCellsSystem.AddCell((int) cell.position.x, cell);
        }

        _cellTransforms = null;
        Destroy(gameObject);
    }

    private void UpdateTransform()
    {
        transform.position = TetrominoPosition;
    }
}
