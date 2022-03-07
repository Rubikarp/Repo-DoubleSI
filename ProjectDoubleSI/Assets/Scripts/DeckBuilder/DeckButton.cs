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
    }

    public void UpdateButton(CardSCO card)
    {
        cardOlder = card;
        buttonImage.sprite = cardOlder.cardAsset;
    }


}
