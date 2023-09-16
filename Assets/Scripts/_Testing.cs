using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class _Testing : MonoBehaviour
{
    _Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new _Grid(20, 10, 5f, new Vector3(0, 0));
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            int value = grid.GetValue(position);
            grid.SetValue(position, value + 5);
            
        }
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }
}
