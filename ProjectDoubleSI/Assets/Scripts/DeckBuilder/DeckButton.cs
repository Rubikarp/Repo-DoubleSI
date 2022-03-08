using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckButton : MonoBehaviour
{

    private Image buttonImage;
    private CardSCO cardOlder;

    public int index;
    public bool recipe;
    SCODeckManagement deck;
    void Awake()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = null;
        deck = SCODeckManagement.instance;
    }

    [NaughtyAttributes.Button]
    public void UpdateButton()
    {
        if (recipe)
        {
            if (deck.playerRecipesDeck.Count > index)
            {
                cardOlder = deck.playerRecipesDeck[index];
                buttonImage.sprite = cardOlder.cardAsset;
                buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 1f);
            }
            else
            {
                cardOlder = null;
                buttonImage.sprite = null;
                buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 0f);
            }
        }
        else
        {
            if (deck.playerToolsDeck.Count > index)
            {
                cardOlder = deck.playerToolsDeck[index];
                buttonImage.sprite = cardOlder.cardAsset;
                buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 1f);
            }
            else
            {
                cardOlder = null;
                buttonImage.sprite = null;
                buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 0f);
            }
        }
    }

    [NaughtyAttributes.Button]
    public void Unequip()
    {
        if (recipe)
        {
            deck.playerRecipesDeck.Remove(cardOlder);
        }
        else
        {
            deck.playerToolsDeck.Remove(cardOlder);
        }

        DeckManager.Instance.UpdateDeckButton();
    }


}
