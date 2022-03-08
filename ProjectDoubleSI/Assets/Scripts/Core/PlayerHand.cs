using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [Header("Data")]
    [NaughtyAttributes.Expandable]
    public List<RecipeSCO> recipes = new List<RecipeSCO>();

    [Header("Info")]
    [NaughtyAttributes.Expandable]
    public List<FoodSCO> availableIngredients = new List<FoodSCO>();

    private void Awake()
    {
        UpdateAvailableList();
    }

    [NaughtyAttributes.Button]
    public void UpdateAvailableList()
    {
        availableIngredients = new List<FoodSCO>();

        foreach (var recipe in recipes)
        {
            foreach (var ingredient in recipe.ingredients)
            {
                availableIngredients.Add(ingredient);
            }
        }
    }
}
