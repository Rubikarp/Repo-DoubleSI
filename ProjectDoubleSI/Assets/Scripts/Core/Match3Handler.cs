using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match3Handler : MonoBehaviour
{
    public GameGrid grid;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        grid.DrawGizmos();
    }
}
