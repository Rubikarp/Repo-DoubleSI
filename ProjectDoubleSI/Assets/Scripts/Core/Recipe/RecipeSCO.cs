using NaughtyAttributes;
using UnityEngine;
using Core;

[CreateAssetMenu(fileName = "Recipe_New", menuName = "Sciptable/Recette")]
public class RecipeSCO : ScriptableObject
{
    public string name = "Brand New Recipe";
    [Expandable, Space(10)]
    public FoodSCO[] ingredients;
    public Season period = Season.Neutral;
}
