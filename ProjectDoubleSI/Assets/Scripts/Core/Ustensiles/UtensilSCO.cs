using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "Utensil_New", menuName = "Sciptable/Utensil")]
public class UtensilSCO : ScriptableObject
{
    [ShowAssetPreview]
    public Sprite sprite;
    public string utensilName;
    public GamePowers effect;

    [Range(0, 4)]
    public int manaCost = 1;
    [Range(0, 60)]
    public float cooldown = 10.0f;
    public AudioClip UstensilVFX;

    public string powerText;

#if UNITY_EDITOR

    [Button]
    private void RenameObject()
    {
        string[] name = sprite.name.Split('_');
        utensilName = name[1];
        string assetPath = UnityEditor.AssetDatabase.GetAssetPath(this.GetInstanceID());
        UnityEditor.AssetDatabase.RenameAsset(assetPath, "Utensil_" + utensilName);
        UnityEditor.AssetDatabase.Refresh();
    }
#endif
}
