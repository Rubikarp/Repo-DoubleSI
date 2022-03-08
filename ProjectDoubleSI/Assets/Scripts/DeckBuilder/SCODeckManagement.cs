using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SCODeckManagement : ScriptableSingleton<SCODeckManagement>
{
    /// <summary>
    /// XP - This script handle the management of the Deck : Visual and Datas.
    /// XP - The player is able to equip cards.
    /// </summary>

    public static SCODeckManagement deckManager;

    #region StartVar
    public List<CardSCO> allCards = new List<CardSCO>();
    [SerializeField] private int numberOfCards;
    public List<CardSCO> playerToolsDeck = new List<CardSCO>();
    public List<CardSCO> playerRecipesDeck = new List<CardSCO>();
    #endregion

    [NaughtyAttributes.Button]
    public void GetAllCard()
    {
        allCards = new List<CardSCO>();
        // Load all skins into memory
        CardSCO[] cardFind = Resources.FindObjectsOfTypeAll(typeof(CardSCO)) as CardSCO[];
        allCards.AddRange(cardFind);

    }
}
