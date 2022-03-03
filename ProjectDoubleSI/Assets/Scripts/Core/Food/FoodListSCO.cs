using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodList", menuName = "Sciptable/FoodList")]
public class FoodListSCO : ScriptableObject
{
    [Expandable]
    public FoodSCO[] allFood;

    public FoodSCO GetRandomFood()
    {
        return allFood.Random();
    }

    [Button]
    public void FetchAPIData()
    {
        foreach (var food in allFood)
        {
            food.freshness = Random.Range(10f, 90f);
        }
    }
}
