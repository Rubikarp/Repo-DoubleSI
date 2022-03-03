using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Match3Handler : MonoBehaviour
{
    public GameGrid grid;
    [Space(10)]
    public Transform elementStock;
    public GameObject gametilePrefab;

    void Start()
    {
        grid.UpdateZone();
    }

    void Update()
    {
        
    }

    [Button]
    public void FillGrid()
    {
        foreach (var tile in grid.tiles)
        {
            if (tile.item != null) return;

#if UNITY_EDITOR
            GameObject go = PrefabUtility.InstantiatePrefab(gametilePrefab, elementStock) as GameObject;
#else
            GameObject go = Instantiate(gametilePrefab, elementStock);
#endif
            go.name = "Element_(" + tile.gridPos.x + "/" + tile.gridPos.y + ")";
            go.transform.position = tile.worldPos;

            tile.item = go;
        }
    }

    [ContextMenu("Set-Up")]
    public void SetUpGrid()
    {
        grid.FillGrid();
    }

    private void OnDrawGizmos()
    {
        grid.DrawGizmos();
    }
}
