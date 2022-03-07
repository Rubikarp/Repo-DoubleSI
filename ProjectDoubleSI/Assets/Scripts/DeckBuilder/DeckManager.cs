using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    /// <summary>
    /// XP - This script handle the management of the Deck : Visual and Datas.
    /// XP - The player is able to equip cards.
    /// </summary>

    //Aliments
    [SerializeField] private GameObject alimentsParents;
    public List<GameObject> alimentsChildren = new List<GameObject>();

    #region StartVar
    public List<GameObject> playerDeck = new List<GameObject>();
    public List<GameObject> playerCollection = new List<GameObject>();
    public List<GameObject> playerRecipes = new List<GameObject>();
    public List<GameObject> playerTools = new List<GameObject>();
    public GameObject collectionParent;
    public GameObject deckParent;
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
            playerCollection.Add(child.gameObject);
        }

        //Récupérer les recipes de la collection pour les ranger dans une liste
        for (int i = 0; i < 6; i++)
        {
            playerTools.Add(playerCollection[i].gameObject);
        }

        //Récupérer les Tools de la collection pour les ranger dans une liste
        for (int i = 6; i < 12; i++)
        {
            playerRecipes.Add(playerCollection[i].gameObject);
        }
    }
        //Pour chaque button dans la liste : Initialisation des visuels des boutons.
}


