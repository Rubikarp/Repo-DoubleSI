using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[RequireComponent(typeof(FoodItem))]
public class FoodItemVisual : MonoBehaviour
{
    [SerializeField] FoodItem foodItem;
    public SpriteRenderer render;
    public SpriteRenderer renderShadow;

    void OnEnable()
    {
        foodItem.onChangingFood.AddListener(UpdateSprite);
    }
    private void OnDisable()
    {
        foodItem.onChangingFood.RemoveListener(UpdateSprite);
    }

    [Button]
    public void UpdateSprite()
    {
        UpdateSprite(foodItem);
    }
    private void UpdateSprite(FoodItem foodItem)
    {
        render.sprite = foodItem.Food.visual;
        renderShadow.sprite = foodItem.Food.visual;
    }
}
