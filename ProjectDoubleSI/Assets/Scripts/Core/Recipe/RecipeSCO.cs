using NaughtyAttributes;
using UnityEngine;
using Core;

[CreateAssetMenu(fileName = "Recipe_New", menuName = "Sciptable/Recette")]
public class RecipeSCO : ScriptableObject
{
    public string recipeName = "Brand New Recipe";
    public Season period = Season.Neutral;

    public GamePowers power;

    [ShowAssetPreview]
    public Sprite recipeSprite;

    [Expandable, Space(10)]
    public FoodSCO[] ingredients;

    #if UNITY_EDITOR
    [Button]
    private void RenameObject()
    {
        string[] name = recipeSprite.name.Split('_');
        recipeName = name[1];
        string assetPath = UnityEditor.AssetDatabase.GetAssetPath(this.GetInstanceID());
        UnityEditor.AssetDatabase.RenameAsset(assetPath, "Recipe_" + recipeName);
        UnityEditor.AssetDatabase.Refresh();
    }
    #endif
}
