using UnityEngine;

[CreateAssetMenu(fileName = "TetrominoData", menuName = "Scriptable Object/TetrominoData", order = 1)]
public class TetrominoData : ScriptableObject
{
    public TetrominoType _tetrominoType;
    public GameObject _cellTile;
    public Vector3Int[] _cells;

    private void OnEnable()
    {
        _cells = new Vector3Int[Data.Cells.Count];
        for (var i = 0; i < Data.Cells[_tetrominoType].Length; i++)
        {
            _cells[i] = (Vector3Int) Data.Cells[_tetrominoType][i];
        }
    }

    private void OnDisable()
    {
        _cells = null;
    }
}