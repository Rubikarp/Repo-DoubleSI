using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Feedbacks;
using UnityEngine.EventSystems;

public class CollectionButton : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    public CardSCO cardContener;
    private Image buttonAsset;
    [SerializeField] private TextMeshProUGUI cost;
    public Image spriteCard;
    [SerializeField] private TextMeshProUGUI ngFragments;
    [SerializeField] private Image fillIn;
    private float cardCost;

    [SerializeField] SCODeckManagement deck;

    [SerializeField] private GameObject[] circle;
    [SerializeField] private Image[] aliment;

    void Start()
    {
        buttonAsset = GetComponent<Image>();
        Initialisation();
    }

    void Initialisation()
    {
        spriteCard.sprite = cardContener.cardAsset;
        if (cardContener.typeOfCard == CardSCO.cardType.Recipe)
        {
            cardCost= cardContener.recipe.ingredients.Length;
            cost.text = cardCost.ToString();

            for (int i = 0; i < cardContener.recipe.ingredients.Length; i++)
            {
                circle[i].SetActive(true);
                aliment[i].sprite = cardContener.recipe.ingredients[i].visual;
                cardContener.cardEffet = cardContener.recipe.powerText;
            }
        }
        else
        {
            cardCost = cardContener.cardCost;
            cost.text = cardCost.ToString();
            
        }
    }

   [SerializeField] private MMF_Player equipSFX;

    public void CallDetails()
    {
        deck.detailCard = cardContener;
        DeckManager.Instance.detailsMenu.PopDetails(cardContener);
    }

    public bool isPressed;

    // Start is called before the first frame update
    public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressed)
        {
            StartCoroutine(WaitBeforeCallDetails());
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        CoroutineStated();
        isPressed = false;
    }

    bool coroutineStarted = false;

    private IEnumerator WaitBeforeCallDetails()
    {
        coroutineStarted = true;
        yield return new WaitForSeconds(0.35f);
        if (isPressed)
        {
            coroutineStarted = false;
            isPressed = false;
            CallDetails();
        }
    }

    private void CoroutineStated()
    {
        if (coroutineStarted)
        {
            StopAllCoroutines();
        }
    }


    //Faire que le joueur puisse s'équiper de recette au maximum de 6 aliments différents.
    public void Equip()
    {
        

        if (cardContener.typeOfCard == CardSCO.cardType.Recipe)
        {
            if (deck.playerRecipesDeck.Count < 3)
            {
                if (!deck.playerRecipesDeck.Contains(cardContener))
                {
                    deck.playerRecipesDeck.Add(cardContener);
                    DeckManager.Instance.UpdateDeckButton();
                    deck.GetAvailableAliment();
                    DeckManager.Instance.UpdateAliment();
                    equipSFX.PlayFeedbacks();
                }
            }
        }
        else
        {
            if (deck.playerToolsDeck.Count < 3)
            {
                if (!deck.playerToolsDeck.Contains(cardContener))
                {
                    deck.playerToolsDeck.Add(cardContener);
                    DeckManager.Instance.UpdateDeckButton();
                    DeckManager.Instance.UpdateToolsValue();
                    equipSFX.PlayFeedbacks();
                }
            }
        }
    }
}
