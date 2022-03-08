using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceHolderUstensile : MonoBehaviour
{
    public string toolName;
    public float toolPrice;
    public Text toolNameRenderer;
    public Button toolCard;
    private float toolCooldown = 10;
    public Text toolCooldownRenderer;
    private bool toolReady = true;

    private ManaManager manaManager;

    // Start is called before the first frame update
    void Start()
    {
        manaManager = ManaManager.Instance;
        toolNameRenderer.text = toolName + "(" + toolPrice + ")";
    }

    // Update is called once per frame
    void Update()
    {
        if (toolReady == true && manaManager.availableMana >= toolPrice)
        {
            toolCooldownRenderer.text = "Prêt !";
        }
        else
        {
            toolCooldownRenderer.text = "Pas prêt !";
        }
    }

    public void ToolPower()
    {
        if (toolPrice <= manaManager.availableMana && toolReady == true)
        {
            print("Power Activated");
            manaManager.availableMana = manaManager.availableMana - toolPrice;
            StartCoroutine(CooldownCoroutine());
        }
    }

    IEnumerator CooldownCoroutine()
    {
        toolReady = false;
        yield return new WaitForSeconds(toolCooldown);
        toolReady = true;
    }
}
    