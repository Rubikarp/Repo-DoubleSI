using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeDrawer : MonoBehaviour
{
    public PlayerHand playerHand;

    [SerializeField] Image[] recipeImage;

    [SerializeField] Image[] recipeA_IngredientImage;
    [SerializeField] Image[] recipeB_IngredientImage;
    [SerializeField] Image[] recipeC_IngredientImage;

    void Start()
    {
        for (int i = 0; i < recipeImage.Length; i++)
        {
            recipeImage[i].sprite = playerHand.recipes[i].recipeSprite;
        }

        for (int j = 0; j < recipeA_IngredientImage.Length; j++)
        {
            if(playerHand.recipes[0].ingredients.Length > j)
            {
                recipeA_IngredientImage[j].sprite = playerHand.recipes[0].ingredients[j].visual;
            }
            else
            {
                recipeA_IngredientImage[j].gameObject.SetActive(false);
            }
        }
        for (int j = 0; j < recipeA_IngredientImage.Length; j++)
        {
            if (playerHand.recipes[1].ingredients.Length > j)
            {
                recipeB_IngredientImage[j].sprite = playerHand.recipes[1].ingredients[j].visual;
            }
            else
            {
                recipeB_IngredientImage[j].gameObject.SetActive(false);
            }
        }
        for (int j = 0; j < recipeA_IngredientImage.Length; j++)
        {
            if (playerHand.recipes[2].ingredients.Length > j)
            {
                recipeC_IngredientImage[j].sprite = playerHand.recipes[2].ingredients[j].visual;
            }
            else
            {
                recipeC_IngredientImage[j].gameObject.SetActive(false);
            }
        }
    }
}
