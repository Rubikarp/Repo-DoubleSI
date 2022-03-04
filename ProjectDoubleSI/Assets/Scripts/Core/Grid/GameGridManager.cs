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

    [Button]
    private void FillGrid()
    {
        FoodItem tempItem;
        foreach (var tile in grid.tiles)
        {
            InvockFoodOn(tile,out tempItem);
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
