using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    /// <summary>
    /// XP - This script handle the management of the Deck : Visual and Datas.
    /// XP - The player is able to equip cards.
    /// </summary>

    
    #region StartVar
    public List<CardSCO> allCards = new List<CardSCO>();
    public List<GameObject> playerToolDeck = new List<GameObject>();
    public List<GameObject> playerRecipeDeck = new List<GameObject>();
    #endregion

    #region UI
    public List<GameObject> playerCollectionButton = new List<GameObject>();
    public List<GameObject> playerRecipesButton = new List<GameObject>();
    public List<GameObject> playerToolsButton = new List<GameObject>();
    public GameObject collectionParent;
    public GameObject deckParent;

    //Aliments
    [SerializeField] private GameObject alimentsParents;
    public List<GameObject> alimentsChildren = new List<GameObject>();
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        //Je récupère l'ensemble des points permettant d'afficher les aliments selon les recettes équipées.
        foreach(Transform child in alimentsParents.transform)
        {
            alimentsChildren.Add(child.gameObject);
        }

        foreach(Transform child in collectionParent.transform)
        {
            playerCollectionButton.Add(child.gameObject);
        }

        //Récupérer les recipes de la collection pour les ranger dans une liste
        for (int i = 0; i < 6; i++)
        {
            playerToolsButton.Add(playerCollectionButton[i].gameObject);
          
        }

        //Récupérer les Tools de la collection pour les ranger dans une liste
        for (int i = 6; i < 12; i++)
        {
            playerRecipesButton.Add(playerCollectionButton[i].gameObject);
        }
    }
        //Pour chaque button dans la liste : Initialisation des visuels des boutons.
}


