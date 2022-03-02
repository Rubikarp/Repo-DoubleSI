using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

[CreateAssetMenu(fileName = "Recipe_New", menuName = "Scipatable/Recette")]
public class RecipeSCO : ScriptableObject
{
    public  string recipeName = "Brand New Recipe";
    [Space(10)]
    public Season period = Season.Neutral;
    public FoodType[] ingredients;
}
