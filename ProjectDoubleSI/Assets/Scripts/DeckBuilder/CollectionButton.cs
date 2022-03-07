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

        if(cardContener.typeOfCard == CardSCO.cardType.Recipe)
        {
            if(SCODeckManagement.instance.playerRecipeDeck.Count == 0)
            {
                SCODeckManagement.instance.playerRecipeDeck.Add(cardContener);
            }
            else
            {
                if (SCODeckManagement.instance.playerRecipeDeck.Count < 3)
                {
                    for (int i = 0; i < SCODeckManagement.instance.playerRecipeDeck.Count; i++)
                    {
                        if (SCODeckManagement.instance.playerRecipeDeck[i] == cardContener)
                        {
                            return;
                        }
                    }

                    SCODeckManagement.instance.playerRecipeDeck.Add(cardContener);
                }
            }

            
        }
        else
        {
            if (SCODeckManagement.instance.playerToolDeck.Count == 0)
            {
                SCODeckManagement.instance.playerToolDeck.Add(cardContener);
            }
            else
            {
                if (SCODeckManagement.instance.playerToolDeck.Count < 3)
                {
                    for (int i = 0; i < SCODeckManagement.instance.playerToolDeck.Count; i++)
                    {
                        if (SCODeckManagement.instance.playerToolDeck[i] == cardContener)
                        {
                            return;
                        }
                    }

                    SCODeckManagement.instance.playerToolDeck.Add(cardContener);
                }
            }

            
        }
    }
}
