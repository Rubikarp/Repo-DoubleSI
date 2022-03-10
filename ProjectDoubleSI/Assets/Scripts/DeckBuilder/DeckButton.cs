using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeckButton : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{

    private Image buttonImage;
    [SerializeField] private CardSCO cardOlder;

    public int index;
    public bool recipe;
    [SerializeField] SCODeckManagement deck;
    void Awake()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = null;

        if (deck.playerRecipesDeck.Count > 0 || deck.playerToolsDeck.Count > 0)
        {
            UpdateButton();
        }

    }


    public void CallDetails()
    {
        deck.detailCard = cardOlder;
        DeckManager.Instance.detailsMenu.PopDetails(cardOlder);
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
            deck.GetAvailableAliment();
            DeckManager.Instance.UpdateAliment();
        }
        else
        {
            deck.playerToolsDeck.Remove(cardOlder);
            DeckManager.Instance.UpdateToolsValue();
        }

        DeckManager.Instance.UpdateDeckButton();
    }

    public void CallDetailsDeck()
    {
        deck.detailCard = cardOlder;
        DeckManager.Instance.detailsMenu.PopDetails(cardOlder);
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
        isPressed = false;
        CoroutineStated();
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
            CallDetailsDeck();
        }
    }

    private void CoroutineStated()
    {
        if (coroutineStarted)
        {
            StopAllCoroutines();
        }
    }

}
