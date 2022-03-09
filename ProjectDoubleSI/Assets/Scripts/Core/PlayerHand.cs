using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerHand : MonoBehaviour
{
    [Header("Data")]
    [NaughtyAttributes.Expandable]
    public List<RecipeSCO> recipes = new List<RecipeSCO>();

    [Header("Info")]
    [NaughtyAttributes.Expandable]
    public List<FoodSCO> availableIngredients = new List<FoodSCO>();
    [SerializeField] SCODeckManagement deck;

    private void Awake()
    {
        if(deck.playerRecipesDeck.Count > 0)
        {
            recipes = deck.playerRecipesDeck.Select(x => x.recipe).ToList();
        }
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
