using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class RestedCells : MonoBehaviour
{
    public GameObject _sampleCell;
    private readonly Dictionary<Vector3Int, GameObject> _restedCellsCollection = new();

    public Dictionary<Vector3Int, GameObject> RestedCellsCollection => _restedCellsCollection;

    public void OccupyGrid(Vector3Int pos, GameObject go)
    {
        _restedCellsCollection[pos] = go;
        //Instantiate(_sampleCell, go.transform.position, Quaternion.identity);
    }

    public void EraseRows(int[] yPositions)
    {
        var uniqueYPos = yPositions.ToList().Distinct().OrderBy(x => x);
        const int gridsPerRow = (Data.RightWallBoundary - Data.RightWallBoundary) / 2 + 1;
        foreach (var yPos in uniqueYPos)
        {
            var yKeys = _restedCellsCollection.Keys.ToList().FindAll(k => k.y == yPos);
            if (yKeys.Count == 10)
            {
                foreach (var yKey in yKeys)
                {
                    /*Destroy(_restedCellsCollection[yKey]);
                    _restedCellsCollection.Remove(yKey);*/
                    Instantiate(_sampleCell, yKey, quaternion.identity);
                }
            }
        }
    }
}
