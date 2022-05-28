using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestedCells : MonoBehaviour
{
    private Dictionary<int, List<Transform>> _restedCellsCollection = new()
    {
        {-9, new List<Transform>()}, {-7, new List<Transform>()},
        {-5, new List<Transform>()}, {-3, new List<Transform>()},
        {-1, new List<Transform>()}, {1, new List<Transform>()},
        {3, new List<Transform>()}, {5, new List<Transform>()},
        {7, new List<Transform>()}, {9, new List<Transform>()},
        {11, new List<Transform>()}, {13, new List<Transform>()},
        {15, new List<Transform>()}, {17, new List<Transform>()}
    };

    public Dictionary<int, List<Transform>> RestedCellsCollection => _restedCellsCollection;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCell(int column, Transform cellTransform)
    {
        _restedCellsCollection[column].Add(cellTransform);
    }

    public void EraseRows()
    {
        
    }
}
