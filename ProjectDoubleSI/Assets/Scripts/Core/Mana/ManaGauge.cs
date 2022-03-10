using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaGauge : MonoBehaviour
{
    public ManaManager mana;
    public Slider gauge;
    [SerializeField] TextMeshProUGUI mamaDispo;

    void Start()
    {
        ManaUpdate();
        MaxManaUpdate();
    }

    public void ManaUpdate()
    {
        gauge.value = mana.AvailableMana;
        mamaDispo.text = mana.AvailableMana.ToString();
    }
    public void MaxManaUpdate()
    {
        gauge.maxValue = mana.MaxMana;
    }
}
