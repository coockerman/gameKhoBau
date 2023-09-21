using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closedWall : MonoBehaviour
{
    Testing testing;
    private void Start()
    {
        testing = FindObjectOfType<Testing>();
        testing.closedPosWall(this.transform.position);
    }
    
    
    
}
