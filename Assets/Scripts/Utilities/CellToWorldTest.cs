using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellToWorldTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Grid grid = transform.root.GetComponent<Grid>();
        Vector3Int cellPosition = grid.WorldToCell(transform.position);
        transform.position = grid.GetCellCenterWorld(cellPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
