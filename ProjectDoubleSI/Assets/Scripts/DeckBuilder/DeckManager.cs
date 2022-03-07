using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : Singleton<DeckManager>
{
    #region UI
    public List<GameObject> playerCollectionButton = new List<GameObject>();
    public List<GameObject> playerCollectionRecipesButton = new List<GameObject>();
    public List<GameObject> playerCollectionToolsButton = new List<GameObject>();
    public GameObject collectionParent;
    public GameObject deckParent;
    public List<GameObject> playerDeckButton = new List<GameObject>();
    public List<GameObject> playerDeckRecipesButton = new List<GameObject>();
    public List<GameObject> playerDeckToolsButton = new List<GameObject>();

    //Aliments
    [SerializeField] private GameObject alimentsParents;
    public List<GameObject> alimentsChildren = new List<GameObject>();
    #endregion

    public int numberOfCards;

    // Start is called before the first frame update
    void Awake()
    {
        Initialisation();
    }

    private void UpdateDeckButtonVisual()
    {
        //UpdateToolsButton
        for (int i = 0; i < SCODeckManagement.instance.playerToolsDeck.Count; i++)
        {

        }

        //UpdateRecipesButton
        for (int i = 0; i < SCODeckManagement.instance.playerRecipesDeck.Count; i++)
        {

        }
    }


    void Initialisation()
    {
        numberOfCards = SCODeckManagement.instance.allCards.Count;

        //Je r�cup�re les enfants de chaque parent pour les ranger ddans une liste parent.
        foreach (Transform child in alimentsParents.transform)
        {
            alimentsChildren.Add(child.gameObject);
        }

        foreach (Transform child in collectionParent.transform)
        {
            playerCollectionButton.Add(child.gameObject);
        }

        foreach (Transform child in deckParent.transform)
        {
            playerDeckButton.Add(child.gameObject);
        }

        //R�cup�rer les boutons de la collection pour les ranger dans deux listes
            for (int i = 0; i < 6; i++)
            {
                playerCollectionRecipesButton.Add(playerCollectionButton[i].gameObject);
                playerCollectionRecipesButton[i].GetComponent<CollectionButton>().cardContener = SCODeckManagement.instance.allCards[i];
            }

            for (int i = 6; i < 12; i++)
            {
                playerCollectionToolsButton.Add(playerCollectionButton[i].gameObject);
                playerCollectionToolsButton[i-6].GetComponent<CollectionButton>().cardContener = SCODeckManagement.instance.allCards[i];
            }


        //Trier les boutons deck dans deux listes.
            for (int i = 0; i < 3; i++)
            {
                playerDeckToolsButton.Add(playerDeckButton[i].gameObject);
            }

            for (int i = 3; i < 6; i++)
            {
                playerDeckRecipesButton.Add(playerCollectionButton[i].gameObject);
            }

    }
    
}
