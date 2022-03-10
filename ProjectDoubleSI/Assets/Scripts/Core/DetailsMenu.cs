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

    [SerializeField] private GameObject[] circle;
    [SerializeField] private Image[] aliment;

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

            for (int i = 0; i < circle.Length; i++)
            {
                circle[i].SetActive(false);
                aliment[i].color = new Color(aliment[i].color.r, aliment[i].color.g, aliment[i].color.b, 0f);
            }

            for (int i = 0; i < cardToDisplay.recipe.ingredients.Length; i++)
            {
                circle[i].SetActive(true);
                aliment[i].color = new Color(aliment[i].color.r, aliment[i].color.g, aliment[i].color.b, 1f);
                aliment[i].sprite = cardToDisplay.recipe.ingredients[i].visual;
            }

            seasonImage.color = new Color(seasonImage.color.r, seasonImage.color.g, seasonImage.color.b, 1f);
        }
        else
        {
            bgCadre.sprite = diffCadres[1];
            cardCost.text = cardToDisplay.cardCost.ToString();
            cardSkill.text = cardToDisplay.cardEffet;

            for (int i = 0; i < circle.Length; i++)
            {
                circle[i].SetActive(false);
                aliment[i].color = new Color(aliment[i].color.r, aliment[i].color.g, aliment[i].color.b, 0f);
            }

            seasonImage.color = new Color(seasonImage.color.r, seasonImage.color.g, seasonImage.color.b, 0f);

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
