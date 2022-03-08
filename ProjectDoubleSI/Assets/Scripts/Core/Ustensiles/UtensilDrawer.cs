using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UtensilDrawer : MonoBehaviour
{
    [SerializeField] UtensilCard card;
    [Space(10)]
    [SerializeField] Image utensilSprite;
    [SerializeField] TextMeshProUGUI toolNameRenderer;

    void Start()
    {
        UpdateCard();
    }

    public void UpdateCard()
    {
        utensilSprite.sprite = card.utensil.sprite;

        toolNameRenderer.text = card.utensil.utensilName;
    }
}
    