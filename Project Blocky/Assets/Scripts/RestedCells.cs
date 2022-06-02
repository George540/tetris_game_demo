using System.Collections.Generic;
using System.Linq;
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

    private void RemoveFromGrid(Vector3Int pos)
    {
        _restedCellsCollection[pos] = null;
        _restedCellsCollection.Remove(pos);
    }

    public void EraseRows(int[] yPositions)
    {
        var uniqueYPos = yPositions.ToList().Distinct().OrderBy(x => x).ToList();

        var rowsDeleted = 0;
        var lastRowDeleted = 0;
        foreach (var yPos in uniqueYPos)
        {
            var yKeys = _restedCellsCollection.Keys.ToList().FindAll(k => k.y == yPos);
            if (yKeys.Count == Data.gridsPerRow)
            {
                foreach (var yKey in yKeys)
                {
                    if (_restedCellsCollection.ContainsKey(yKey) || _restedCellsCollection[yKey] != null)
                    {
                        Destroy(_restedCellsCollection[yKey]);
                        RemoveFromGrid(yKey);
                    }
                }
                rowsDeleted++;
                lastRowDeleted = yPos;
            }
        }
        
        if (rowsDeleted == 0 || lastRowDeleted == 0) return;
        
        DropUpperCells(rowsDeleted, lastRowDeleted);
    }

    private void DropUpperCells(int rowsDeleted, int lastRowDeleted)
    {
        var keyValuePairsAbove = _restedCellsCollection.ToList().FindAll(k => k.Key.y > lastRowDeleted);
        keyValuePairsAbove = keyValuePairsAbove.OrderBy(k => k.Key.y).ToList();
        

        var distanceToDrop = rowsDeleted * 2;
        foreach (var pair in keyValuePairsAbove)
        {
            pair.Deconstruct(out var oldKey, out var cellObject);
            var decrementVector = new Vector3Int(0, distanceToDrop, 0);
            var newKey = oldKey - decrementVector;
            cellObject.transform.position -= decrementVector;
            _restedCellsCollection[newKey] = cellObject;
            RemoveFromGrid(oldKey);
        }
    }
}
