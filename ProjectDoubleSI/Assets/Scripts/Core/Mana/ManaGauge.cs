using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaGauge : MonoBehaviour
{
    public ManaManager mana;
    public Slider gauge;

    void Start()
    {
        ManaUpdate();
        MaxManaUpdate();
    }

    public void ManaUpdate()
    {
        gauge.value = mana.AvailableMana;
    }
    public void MaxManaUpdate()
    {
        gauge.maxValue = mana.MaxMana;
    }
}
