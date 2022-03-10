using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using NaughtyAttributes;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(GameGrid))]
public class GameGridManager : MonoBehaviour
{
    [SerializeField] GameGrid grid;

    [Header("Data")]
    public Transform elementStock;
    public GameObject gametilePrefab;

    public PlayerHand player;

    [Header("parameter")]
    public float gravityTime = 1.2f;
    public float dropTime = 1.2f;
    public float dropHeight = 10f;

    void Awake()
    {
        grid = transform.GetComponent<GameGrid>();
    }

    public void Switch(GameTile a, GameTile b)
    {
        FoodItem tempItem = a.item;
        a.item = b.item;
        b.item = tempItem;

        LeanTween.move(a.item.gameObject, a.worldPos, 0.2f).setEase(LeanTweenType.easeInQuad);
        LeanTween.move(b.item.gameObject, b.worldPos, 0.2f).setEase(LeanTweenType.easeInQuad);
    }

    public void ClearMatch(LineMatch match)
    {
        ClearTiles(match.matchingTile);
        match.End();
    }
    public void ClearTiles(List<GameTile> tiles)
    {
        foreach (var tile in tiles)
        {
            Destroy(tile.item.gameObject);
            tile.item = null;
        }

        GravityCheck();
    }
    
    public void GravityCheck()
    {
        bool gravEnd = true;
        do
        {
            gravEnd = true;
            //De bas en haut + gauch à droite
            for (int x = 0; x < grid.size.x; x++)
            {
                for (int y = 0; y < grid.size.y; y++)
                {
                    if (grid.GetTile(x, y).item == null)
                    {
                        for (int i = y; i < grid.size.y; i++)
                        {
                            if (grid.GetTile(x, i).item == null)
                            { continue; }

                            DropDown(grid.GetTile(x, i), grid.GetTile(x, y));
                            gravEnd = false;
                            break;
                        }
                    }
                }
            }
        } while (!gravEnd);
        FillEmptyTiles();
    }
    public void DropDown(GameTile from, GameTile to)
    {
        to.item = from.item;
        from.item = null;

        LeanTween.move(to.item.gameObject, to.worldPos, gravityTime * (from.gridPos-to.gridPos).magnitude).setEase(LeanTweenType.easeOutBounce);
    }
    public void FillEmptyTiles()
    {
        FoodItem tempItem;
        foreach (var tile in grid.tiles)
        {
            if (tile.item == null)
            {
                InvockFoodOn(tile, out tempItem);
                tempItem.Food = player.availableIngredients.Random();
                tempItem.transform.position = tile.worldPos + Vector3.up * dropHeight;
                LeanTween.move(tempItem.gameObject, tile.worldPos, dropTime).setEase(LeanTweenType.easeOutBounce);
            }
        }
        UpdateName();
    }


    [Button]
    private void GenerateGrid()
    {
        FoodItem tempItem;
        foreach (var tile in grid.tiles)
        {
            InvockFoodOn(tile, out tempItem);
            tempItem.Food = player.availableIngredients.Random();
        }
        UpdateName();
    }

    public void ShuffleGrid()
    {
        FoodItem tempItem;
        foreach (var tile in grid.tiles)
        {
            tempItem = tile.item;
            tempItem.Food = player.availableIngredients.Random();
#if UNITY_EDITOR
            tempItem.onChangingFood?.Invoke(tempItem);
#endif
        }
        UpdateName();
    }

    public List<GameTile> SelectALine(bool vertical, int index)
    {
        List<GameTile> aimTiles = new List<GameTile>();
        if (vertical)
        {
            index = Mathf.Clamp(index, 0, grid.size.x);
            for (int i = 0; i < grid.size.y; i++)
            {
                aimTiles.Add(grid.GetTile(index, i));
            }
        }
        else
        {
            index = Mathf.Clamp(index, 0, grid.size.y);
            for (int i = 0; i < grid.size.x; i++)
            {
                aimTiles.Add(grid.GetTile(i, index));
            }
        }
        return aimTiles;
    }
    private void UpdateName()
    {
        FoodItem tempItem;
        foreach (var tile in grid.tiles)
        {
            tile.item.gameObject.name = "Food_" + tile.item.Food.name + "_" + tile.gridPos;
        }
    }

    public void InvockFoodOn(GameTile tile, out FoodItem item)
    {
        item = null;
        if (tile.item != null)
        {
#if UNITY_EDITOR
            DestroyImmediate(tile.item.gameObject);
#else
            Destroy(tile.item.gameObject);
#endif

        }

#if UNITY_EDITOR
        GameObject go = PrefabUtility.InstantiatePrefab(gametilePrefab, elementStock) as GameObject;
#else
        GameObject go = Instantiate(gametilePrefab, elementStock);
#endif

        tile.item = go.GetComponent<FoodItem>();
        item = tile.item;

        go.transform.position = tile.worldPos;
    }
}
