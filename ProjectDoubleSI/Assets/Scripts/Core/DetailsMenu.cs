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
    

    public void PopDetails(CardSCO cardToDisplay)
    {
        cardName.text = cardToDisplay.cardName;

        parent.SetActive(true);
        if (cardToDisplay.typeOfCard == CardSCO.cardType.Recipe)
        {
            bgCadre.sprite = diffCadres[0];
            cardCost.text = cardToDisplay.recipe.ingredients.Length.ToString();
            cardSkill.text = cardToDisplay.cardEffet;

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
