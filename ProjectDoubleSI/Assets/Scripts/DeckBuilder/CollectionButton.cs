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


    public void Equip()
    {
        if (cardContener.typeOfCard == CardSCO.cardType.Recipe)
        {
            if (SCODeckManagement.instance.playerRecipesDeck.Count < 3)
            {
                if (!SCODeckManagement.instance.playerRecipesDeck.Contains(cardContener))
                {
                    SCODeckManagement.instance.playerRecipesDeck.Add(cardContener);
                    DeckManager.Instance.UpdateDeckButton();
                }
            }
        }
        else
        {
            if (SCODeckManagement.instance.playerRecipesDeck.Count < 3)
            {
                if (!SCODeckManagement.instance.playerToolsDeck.Contains(cardContener))
                {
                    SCODeckManagement.instance.playerToolsDeck.Add(cardContener);
                    DeckManager.Instance.UpdateDeckButton();
                }
            }
        }
    }


}
