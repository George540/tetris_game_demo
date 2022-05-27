using System.Linq;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3Int TetrominoPosition { get; set; }
    public TetrominoData _data;
    private Transform[] _cellTransforms;

    public void Initialize(TetrominoData data, Vector3Int startPos)
    {
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
        if (_cellTransforms.ToList().Any(c => c.position.y <= -19)) return;
        
        TetrominoPosition += Vector3Int.down * dropDistance;
        UpdateTransform();
    }

    public void MoveRight(int moveDistance)
    {
        if (_cellTransforms.ToList().Any(c => c.position.x >= 9)) return;
        
        TetrominoPosition += Vector3Int.right * moveDistance;
        UpdateTransform();
    }

    public void MoveLeft(int moveDistance)
    {
        if (_cellTransforms.ToList().Any(c => c.position.x <= -9)) return;
        
        TetrominoPosition += Vector3Int.left * moveDistance;
        UpdateTransform();
    }

    private void UpdateTransform()
    {
        transform.position = TetrominoPosition;
    }
}
