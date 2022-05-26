using UnityEngine;

public class Piece : MonoBehaviour
{
    public Vector3Int Position { get; private set; }
    public TetrominoData Data { get; private set; }
    public Vector3Int[] Cells { get; private set; }
    
    public void Initialize(Vector3Int position, TetrominoData data)
    {
        Position = position;
        Data = data;
        Cells ??= new Vector3Int[Data.Cells.Length];

        for (var i = 0; i < Data.Cells.Length; i++)
        {
            Cells[i] = (Vector3Int) Data.Cells[i];
        }
    }
}
