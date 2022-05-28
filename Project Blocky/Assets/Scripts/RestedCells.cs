using System.Collections.Generic;
using UnityEngine;

public class RestedCells : MonoBehaviour
{
    public GameObject _sampleCell;
    private Dictionary<Vector3Int, GameObject> _restedCellsCollection = new Dictionary<Vector3Int, GameObject>();

    public Dictionary<Vector3Int, GameObject> RestedCellsCollection => _restedCellsCollection;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OccupyGrid(Vector3Int pos, GameObject go)
    {
        _restedCellsCollection[pos] = go;
        Instantiate(_sampleCell, go.transform.position, Quaternion.identity);
    }

    public void EraseRows()
    {
        
    }
}
