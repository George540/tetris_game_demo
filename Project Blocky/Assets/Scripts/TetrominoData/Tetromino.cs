using System;
using System.Linq;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private GameManager _gameManager;
    
    // Start is called before the first frame update
    private Vector3Int TetrominoPosition { get; set; }
    private TetrominoData _data;
    private Transform[] _cellTransforms;
    private bool _isRested;
    // ReSharper disable once ConvertToAutoProperty
    public bool IsRested => _isRested;

    public bool HasData()
    {
        return _data != null;
    }
    
    public void Initialize(GameManager manager, TetrominoData data, Vector3Int startPos)
    {
        _gameManager = manager;
        _data = data;
        _cellTransforms ??= new Transform[_data._cells.Length];
        TetrominoPosition = startPos;
        for (var i = 0; i < data._cells.Length; i++)
        {
            var go = Instantiate(data._cellTile, TetrominoPosition, Quaternion.identity, transform);
            go.transform.localPosition = data._cells[i];
            _cellTransforms[i] = go.transform;
        }
    }

    public void DropTetromino(int dropDistance)
    {
        if (_data == null) return;
        
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
        if (!_data._hasRotation) return;
        
        transform.Rotate(Vector3.forward, 90f);
        if (_cellTransforms.Any(c =>
            _gameManager.RestedCellsSystem.RestedCellsCollection.ContainsKey(Vector3Int.FloorToInt(c.position))))
        {
            transform.Rotate(Vector3.back, 90f);
            return;
        }
        foreach (var cell in _cellTransforms)
        {
            cell.Rotate(Vector3.back, 90f);
        }

        if (_cellTransforms.Any(c => c.position.x < Data.LeftWallBoundary))
        {
            TetrominoPosition += new Vector3Int(2, 0, 0);
        }
        else if (_cellTransforms.Any(c => c.position.x > Data.RightWallBoundary))
        {
            TetrominoPosition -= new Vector3Int(2, 0, 0);
        }

        UpdateTransform();
    }

    private void RestTetromino()
    {
        var yPos = new int[_cellTransforms.Length];
        var i = 0;
        foreach (var cell in _cellTransforms)
        {
            cell.parent = _gameManager.RestedCellsSystem.transform;
            var position = Vector3Int.FloorToInt(cell.position);
            _gameManager.RestedCellsSystem.OccupyGrid(position, cell.gameObject);
            yPos[i] = position.y;
            i++;
        }

        _data = null;
        _cellTransforms = null;
        _gameManager.RestedCellsSystem.EraseRows(yPos);
        _gameManager.CreateTetromino(_gameManager.GetNextTetromino());
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
