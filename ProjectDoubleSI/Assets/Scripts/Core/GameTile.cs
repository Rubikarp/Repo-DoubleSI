using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class GameTile
{
    public GameObject item;

    [Header("Position")]
    public Vector2Int gridPos;
    public Vector3   worldPos;
    public Vector2 worldPos2D
    {
        get
        {
            return worldPos;
        }
    }

    /*#if UNITY_EDITOR
    GameObject go = PrefabUtility.InstantiatePrefab(gametilePrefab, elementStock) as GameObject;
    #else
    GameObject go = Instantiate(gametilePrefab, elementStock);
    #endif 
    go.name = "Tile_(" + x + "/" + y + ")";
    go.transform.position = TileToPos(new Vector2Int(x, y));
    
    GameTile tile = go.GetComponent<GameTile>();
    if (tile == null)
    {
        Debug.LogError("can't Find Tile on the object");
    }
    
    tile.gridPos = new Vector2Int(x, y);*/
}
