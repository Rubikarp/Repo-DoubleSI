using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionButton : MonoBehaviour
{
    public CardSCO cardContener;
    private Image buttonAsset;
    private int cardCost;

    // Start is called before the first frame update
    void Start()
    {
        buttonAsset = GetComponent<Image>();
        Initialisation();
    }

    void Initialisation()
    {
        buttonAsset.sprite = cardContener.cardAsset;
    }

    /*
    public void Equip()
    {
        if(cardContener.typeOfCard == CardSCO.cardType.Recipe)
        {
            //Si il n'y a pas déja 3 cartes.
            
        }
        else
        {

        }
    }*/
}
