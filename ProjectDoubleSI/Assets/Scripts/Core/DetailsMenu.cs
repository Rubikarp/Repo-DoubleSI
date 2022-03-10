using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetailsMenu : MonoBehaviour
{
    [SerializeField] private GameObject parent;

    [SerializeField] private Image bgCadre;
    [SerializeField] private Sprite[] diffCadres;
    [SerializeField] private Image cardVisual;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardSkill;
    [SerializeField] private TextMeshProUGUI cardCost;
    [SerializeField] private Image raretyDisplay;
    [SerializeField] private Sprite[] rarety;
    [SerializeField] private Image seasonImage;
    

    public void PopDetails(CardSCO cardToDisplay)
    {
        cardName.text = cardToDisplay.cardName;

        parent.SetActive(true);
        if (cardToDisplay.typeOfCard == CardSCO.cardType.Recipe)
        {
            bgCadre.sprite = diffCadres[0];
            cardCost.text = cardToDisplay.recipe.ingredients.Length.ToString();
            cardSkill.text = cardToDisplay.cardEffet;

            switch (cardToDisplay.recipe.period)    
            {
                case Core.Season.Error:
                    break;
                case Core.Season.Winter:
                    seasonImage.sprite = DeckManager.Instance.season[2];
                    break;
                case Core.Season.Spring:
                    seasonImage.sprite = DeckManager.Instance.season[3];
                    break;
                case Core.Season.Summer:
                    seasonImage.sprite = DeckManager.Instance.season[4];
                    break;
                case Core.Season.Autumn:
                    seasonImage.sprite = DeckManager.Instance.season[1];
                    break;
                case Core.Season.Neutral:
                    seasonImage.sprite = DeckManager.Instance.season[0];
                    break;
                default:
                    break;
            }

        }
        else
        {
            bgCadre.sprite = diffCadres[1];
            cardCost.text = cardToDisplay.cardCost.ToString();
            cardSkill.text = cardToDisplay.cardEffet;
        }

        cardVisual.sprite = cardToDisplay.cardAsset;

        switch (cardToDisplay.raretyOfTheCard)
        {
            case CardSCO.cardRarety.Common:
                raretyDisplay.sprite = rarety[0];
                break;
            case CardSCO.cardRarety.Rare:
                raretyDisplay.sprite = rarety[1];
                break;
            case CardSCO.cardRarety.Epic:
                raretyDisplay.sprite = rarety[2];
                break;
            case CardSCO.cardRarety.Legendary:
                raretyDisplay.sprite = rarety[3];
                break;
            default:
                break;
        }
    }
    public void Quit()
    {
        parent.SetActive(false);     
    }
}
