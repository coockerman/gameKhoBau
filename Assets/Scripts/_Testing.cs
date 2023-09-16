using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class _Testing : MonoBehaviour
{
    [SerializeField] _HeapMapVisual heapMapVisual;
    _Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new _Grid(100, 100, 2f, Vector3.zero);
        heapMapVisual.SetGrid(grid);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            grid.AddValue(position,100, 2, 25);
            
        }
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }
}
