using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "Food_New", menuName = "Sciptable/Food")]
public class FoodSCO : ScriptableObject
{
    [ShowAssetPreview]
    public Sprite visual;
    [Space(10)]
    public FoodType categorie = FoodType.Vegetable;
    public FoodElement element = FoodElement.Salmon;
    [Range(0f, 100f)] 
    public float freshness = 50.0f;
}
