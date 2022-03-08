using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckButton : MonoBehaviour
{

    private Image buttonImage;
    private CardSCO cardOlder;
    // Start is called before the first frame update
    void Awake()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = null;
    }

    public void UpdateButton(CardSCO card)
    {
        cardOlder = card;
        buttonImage.sprite = cardOlder.cardAsset;
    }

    public void Unequip()
    {
        //En fonction de si c'est un tool ou un recipe. Le retirer du deck à une position.
        //Trier la liste afin de retirer le vide.

        buttonImage.sprite = null;
        cardOlder = null;
    }


}
