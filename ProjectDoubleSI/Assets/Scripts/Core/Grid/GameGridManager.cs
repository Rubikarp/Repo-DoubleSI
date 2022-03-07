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

    public FoodListSCO foodList;

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
    public void DropDown(GameTile from, GameTile to)
    {
        to.item = from.item;
        from.item = null;

        LeanTween.move(to.item.gameObject, to.worldPos, 0.2f).setEase(LeanTweenType.easeOutBounce);
    }

    public void GravityCheck()
    {
        bool gravEnd = true;
        do
        {
            gravEnd = true;
            //De bas en haut + gauch � droite
            for (int x = 0; x < grid.size.x; x++)
            {
                for (int y = 0; y < grid.size.y; y++)
                {
                    if (grid.GetTile(x, y).item == null)
                    {
                        if (grid.GetTile(x, y + 1) == null)
                        { continue; }

                        if (grid.GetTile(x, y + 1).item != null)
                        {
                            DropDown(grid.GetTile(x, y + 1), grid.GetTile(x, y));
                            gravEnd = false;
                        }
                    }
                }
            }
        } while (!gravEnd);
        ReFillGrid();
    }

    public void ReFillGrid()
    {
        FoodItem tempItem;
        foreach (var tile in grid.tiles)
        {
            if (tile.item == null)
            {
                InvockFoodOn(tile, out tempItem);
                tempItem.Food = foodList.GetRandomFood();
            }
        }
        UpdateName();
    }

    [Button]
    private void FillGrid()
    {
        FoodItem tempItem;
        foreach (var tile in grid.tiles)
        {
            InvockFoodOn(tile, out tempItem);
            tempItem.Food = foodList.GetRandomFood();
        }
        UpdateName();
    }
    [Button]
    public void ShuffleGrid()
    {
        FoodItem tempItem;
        foreach (var tile in grid.tiles)
        {
            tempItem = tile.item;
            tempItem.Food = foodList.GetRandomFood();

#if UNITY_EDITOR
            tempItem.onChangingFood?.Invoke(tempItem);
#endif
        }
        UpdateName();
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
