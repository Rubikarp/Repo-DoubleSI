using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Card_New", menuName = "Sciptable/Card")]
public class CardSCO : ScriptableObject
{
    public string cardName;
    public int level;

    public Sprite cardAsset;
    public string cardEffet;
    public RecipeSCO recipe;

    public enum cardRarety
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

    public enum cardType
    {
        Tool,
        Recipe
    }

    public cardType typeOfCard = cardType.Tool;
    public cardRarety raretyOfTheCard = cardRarety.Common;
}

   
