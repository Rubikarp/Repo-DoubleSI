using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerHand : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] SCODeckManagement deck;
    [NaughtyAttributes.Expandable]
    public List<RecipeSCO> recipes = new List<RecipeSCO>();
    public List<UtensilSCO> utensils = new List<UtensilSCO>();

    public List<UtensilCard> cardUtensils = new List<UtensilCard>();

    [Header("Info")]
    [NaughtyAttributes.Expandable]
    public List<FoodSCO> availableIngredients = new List<FoodSCO>();

    private void Awake()
    {
        if(deck.playerRecipesDeck.Count > 0)
        {
            recipes = deck.playerRecipesDeck.Select(x => x.recipe).ToList();
        }
        if (deck.playerToolsDeck.Count > 0)
        {
            utensils = deck.playerToolsDeck.Select(x=> x.tool).ToList();
        }
        UpdateAvailableList();

        for (int i = 0; i < cardUtensils.Count; i++)
        {
            if (cardUtensils.Count <= utensils.Count)
            {
                cardUtensils[i].utensil = utensils[i];
            }
        }
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
