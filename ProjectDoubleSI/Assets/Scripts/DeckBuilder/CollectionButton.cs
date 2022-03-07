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
            if(SCODeckManagement.instance.playerRecipesDeck.Count == 0)
            {
                SCODeckManagement.instance.playerRecipesDeck.Add(cardContener);
                DeckManager.Instance.UpdateDeckButton();
                
            }
            else
            {
                if (SCODeckManagement.instance.playerRecipesDeck.Count < 3)
                {
                    for (int i = 0; i < SCODeckManagement.instance.playerRecipesDeck.Count; i++)
                    {
                        if (SCODeckManagement.instance.playerRecipesDeck[i] == cardContener)
                        {
                            return;
                        }
                    }

                    SCODeckManagement.instance.playerRecipesDeck.Add(cardContener);
                    DeckManager.Instance.UpdateDeckButton();
                }
            } 
        }
        else
        {
            if (SCODeckManagement.instance.playerToolsDeck.Count == 0)
            {
                SCODeckManagement.instance.playerToolsDeck.Add(cardContener);
                DeckManager.Instance.UpdateDeckButton();
            }
            else
            {
                if (SCODeckManagement.instance.playerToolsDeck.Count < 3)
                {
                    for (int i = 0; i < SCODeckManagement.instance.playerToolsDeck.Count; i++)
                    {
                        if (SCODeckManagement.instance.playerToolsDeck[i] == cardContener)
                        {
                            return;
                        }
                    }

                    SCODeckManagement.instance.playerToolsDeck.Add(cardContener);
                    DeckManager.Instance.UpdateDeckButton();
                }
            }

            
        }
    }
}
