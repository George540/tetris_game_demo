using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoDisplay : MonoBehaviour
{
    private GameManager _gameManager;
    private TetrominoData _data;
    private Transform[] _cellTransforms = new Transform[4];
    
    public void Initialize(GameManager manager, TetrominoData data)
    {
        _gameManager = manager;
        _data = data;
        _cellTransforms ??= new Transform[_data._cells.Length];
        for (var i = 0; i < data._cells.Length; i++)
        {
            var displayTransform = transform;
            var go = Instantiate(data._cellTile, displayTransform.position, Quaternion.identity, displayTransform);
            go.transform.localPosition = data._cells[i];
            _cellTransforms[i] = go.transform;
        }
    }

    public void RemoveData()
    {
        for (var i = 0; i < _cellTransforms.Length; i++)
        {
            Destroy(_cellTransforms[i].gameObject);
            _cellTransforms[i] = null;
            _data = null;
        }
    }
}
