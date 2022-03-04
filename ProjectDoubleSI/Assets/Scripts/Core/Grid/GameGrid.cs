using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameGrid : MonoBehaviour
{
    [Header("Parameter")]
    public Vector2Int size = new Vector2Int(5, 5);
    public Vector2 offSet = new Vector2Int(0, 0);
    public float cellSize = 1;
    public Rect zone = new Rect(Vector2.zero, Vector2.one * 5f);

    [Header("Data")]
    public GameTile[] tiles;

    #region Debug
    [BoxGroup("Debug")] public bool showDebug;
    [BoxGroup("Debug")] [ShowIf("showDebug")] public Color debugLineColor = Color.red;
    [BoxGroup("Debug")] [ShowIf("showDebug")] public bool showCenter;
    [BoxGroup("Debug")] [ShowIf("showCenter")] public Color debugCenterColor = Color.black;
    #endregion

    public bool InZone(Vector3 pos)
    {
        return InZone(pos.ToPlaneXZ());
    }
    public bool InZone(Vector2 pos)
    {
        return zone.Contains(pos);
    }
    public bool InGrid(int x, int y)
    {
        if (x < 0 || y < 0)
        {
            return false;
        }
        if (x >= size.x || y >= size.y)
        {
            return false;
        }
        return true;
    }
    public bool InGrid(Vector2Int testedPos)
    {
        return InGrid(testedPos.x, testedPos.y);
    }


    public GameTile GetTile(int x, int y)
    {
        if(!InGrid(x,y)) { return null; }
        return tiles[x + (y * (size.x))];
    }
    public GameTile GetTile(Vector2Int pos)
    {
        return GetTile(pos.x, pos.y);
    }
    public FoodSCO GetFood(int x, int y)
    {
        if (GetTile(x, y) == null) return null;
        return GetTile(x,y).item.Food;
    }
    public FoodSCO GetFood(Vector2Int pos)
    {
        return GetFood(pos.x, pos.y);
    }


    #region Grid<->World Convertion
    /// <summary>
    /// Convert a GameGrid Pos to a worldPos
    /// WARNING ! The result can be extrapolate farther than the GridSize
    /// </summary>
    /// <param name="posInGrid"> Position on the GameGrid (can be negative)</param>
    /// <returns></returns>
    public Vector3 TileToPos(Vector2Int posInGrid)
    {
        //Get bottom left corner |_
        Vector3 bottomLeft = new Vector3(offSet.x, 0, offSet.y);
        bottomLeft -= new Vector3(size.x, 0, size.y) * 0.5f * cellSize;
        //Centre de la case
        bottomLeft += new Vector3(cellSize * 0.5f, 0, cellSize * 0.5f);

        Vector3 result = bottomLeft + (new Vector3(posInGrid.x, 0, posInGrid.y) * cellSize);

        return result;
    }
    /// <summary>
    /// Convert a Point on the GamePlane to the GameGrid Pos related
    /// WARNING ! it can result a pos outside of the actual grid
    /// </summary>
    /// <param name="planePos"> point on the plane where you look for the tile</param>
    /// <returns></returns>
    public Vector2Int PosToTile(Vector3 planePos)
    {
        //Get bottom left corner |_
        Vector3 bottomLeft = new Vector3(offSet.x, 0,offSet.y);
        bottomLeft -= new Vector3(size.x, 0, size.y) * 0.5f * cellSize;
        //Pas de centrage sur la case car floor, si round activer la ligne
        //bottomLeft += new Vector3(cellSize * 0.5f, cellSize * 0.5f, 0);

        Vector3 posRelaToGrid = planePos - bottomLeft;
        float returnToCellsize = 1 / cellSize;
        Vector2Int result = new Vector2Int(Mathf.FloorToInt(posRelaToGrid.x * returnToCellsize), Mathf.FloorToInt(posRelaToGrid.z * returnToCellsize));

        return result;
    }
    #endregion

    private void OnValidate()
    {
        UpdateZone();
    }
    public void UpdateZone()
    {
        //Get bottom left corner |_
        Vector2 bottomLeft = offSet;
        bottomLeft -= (Vector2)size * 0.5f * cellSize;

        zone = new Rect(bottomLeft, (Vector2)size * cellSize);
    }

    [Button]
    public void SetGridTiles()
    {
        if (tiles == null || tiles.Length == 0)
        {
            tiles = new GameTile[size.x * size.y];
        }

        GameTile temp;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                if (GetTile(x, y) != null)
                {
                    temp = GetTile(x, y);
                    temp.gridPos = new Vector2Int(x, y);
                    temp.worldPos = TileToPos(temp.gridPos);
                    temp.name = "Tile[" + temp.gridPos.x + "," + temp.gridPos.y + "]";
                }
            }
        }
    }

#if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        if (showDebug)
        {
            Vector3 startPos = new Vector3(offSet.x, 0, offSet.y);
            startPos -= new Vector3(size.x, 0, size.y) * 0.5f * cellSize;

            float halfCell = cellSize * 0.5f;

            if (showCenter)
            {
                using (new Handles.DrawingScope(debugCenterColor))
                {
                    Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;

                    #region center point
                    for (int x = 0; x < size.x; x++)
                    {
                        for (int y = 0; y < size.y; y++)
                        {
                            Handles.DrawWireDisc(startPos + new Vector3(x * cellSize, 0, y * cellSize) + new Vector3(cellSize * 0.5f, 0, cellSize * 0.5f),Vector3.up, cellSize * 0.5f * 0.5f);
                        }
                    }
                    #endregion
                }
            }

            //GameGrid decals
            for (int x = 0; x <= size.x; x++)
            {
                Debug.DrawRay(startPos + new Vector3(cellSize * x, 0, 0), Vector3.forward * size.y * cellSize, debugLineColor);
            }
            for (int y = 0; y <= size.y; y++)
            {
                Debug.DrawRay(startPos + new Vector3(0, 0, cellSize * y), Vector3.right * size.x * cellSize, debugLineColor);
            }
        }
    }
#endif
}
