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
        if (_cellTransforms.Any(c => HasNeighbouringDownCell(c, dropDistance)) ||
            _cellTransforms.ToList().Any(c => c.position.y <= Data.BottomWallBoundary))
        {
            RestTetromino();
            return;
        }

        TetrominoPosition += Vector3Int.down * dropDistance;
        UpdateTransform();
    }

    public void MoveRight(int moveDistance)
    {
        if (_cellTransforms.ToList().Any(c => c.position.x >= Data.RightWallBoundary)) return;
        
        if (_cellTransforms.Any(c => HasNeighbouringRightCell(c, moveDistance)))
        {
            return;
        }

        TetrominoPosition += Vector3Int.right * moveDistance;
        UpdateTransform();
    }

    public void MoveLeft(int moveDistance)
    {
        if (_cellTransforms.ToList().Any(c => c.position.x <= Data.LeftWallBoundary)) return;
        
        if (_cellTransforms.Any(c => HasNeighbouringLeftCell(c, moveDistance)))
        {
            return;
        }
        
        TetrominoPosition += Vector3Int.left * moveDistance;
        UpdateTransform();
    }

    public void Rotate()
    {
        if (_data._hasRotation)
        {
            transform.Rotate(Vector3.forward, 90f);
            foreach (var cell in _cellTransforms)
            {
                cell.Rotate(Vector3.back, 90f);
            }
        }
    }

    private void RestTetromino()
    {
        foreach (var cell in _cellTransforms)
        {
            cell.parent = _gameManager.RestedCellsSystem.transform;
            _gameManager.RestedCellsSystem.OccupyGrid(Vector3Int.FloorToInt(cell.position), cell.gameObject);
        }

        _cellTransforms = null;
        _gameManager.CreateTetromino();
        Destroy(gameObject);
    }

    private void UpdateTransform()
    {
        transform.position = TetrominoPosition;
    }

    
    private bool HasNeighbouringDownCell(Transform cell, int maxDistance)
    {
        var restedCells = _gameManager.RestedCellsSystem.RestedCellsCollection;
        var cellPosition = cell.position;
        var key = Vector3Int.CeilToInt(cellPosition) + Vector3Int.down * maxDistance;
        return restedCells.ContainsKey(key) &&
               restedCells.TryGetValue(key, out var closeCell) &&
               closeCell.transform.position.y + maxDistance >= cellPosition.y;
    }
    
    private bool HasNeighbouringRightCell(Transform cell, int maxDistance)
    {
        var restedCells = _gameManager.RestedCellsSystem.RestedCellsCollection;
        var cellPosition = cell.position;
        var key = Vector3Int.FloorToInt(cellPosition) + Vector3Int.right * maxDistance;
        return restedCells.ContainsKey(key) &&
               restedCells.TryGetValue(key, out var closeCell) &&
               closeCell.transform.position.x - maxDistance <= cellPosition.x;
    }
    
    private bool HasNeighbouringLeftCell(Transform cell, int maxDistance)
    {
        var restedCells = _gameManager.RestedCellsSystem.RestedCellsCollection;
        var cellPosition = cell.position;
        var key = Vector3Int.FloorToInt(cellPosition) + Vector3Int.left * maxDistance;
        return restedCells.ContainsKey(key) &&
               restedCells.TryGetValue(key, out var closeCell) &&
               closeCell.transform.position.x + maxDistance >= cellPosition.x;
    }
}
