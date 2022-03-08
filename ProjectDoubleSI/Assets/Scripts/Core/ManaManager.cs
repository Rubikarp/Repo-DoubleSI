using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public float maxMana = 4;
    public float availableMana = 0;
    public Text manaRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        manaRenderer.text = "Saveur : " + availableMana.ToString();

        if(availableMana > maxMana)
        {
            availableMana = 4;
        }
    }

    public void AddMana(LineMatch match)
    {
        availableMana = availableMana + 1;
    }
}
