using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class UtensilCard : MonoBehaviour
{
    [Expandable]
    public UtensilSCO utensil;
    public ManaManager mana;
    public PowerEvent onCardEffect;


    public bool NotEnabled => false;
    [EnableIf("NotEnabled")]
    public bool usable = true;
    public float restingTime;
    private IEnumerator coolDownMethode;

    public void UseCard()
    {
        if (usable)
        {
            //If not enough mana
            if (!mana.CanCast(utensil.manaCost)) return;

            //EFFECT
            mana.LoseMana(utensil.manaCost);
            onCardEffect?.Invoke(utensil.effect);

            coolDownMethode = CoolDown(utensil.cooldown);
            StartCoroutine(coolDownMethode);
        }
    }

    public IEnumerator CoolDown(float CD)
    {
        usable = false;
        restingTime = CD;
        while (restingTime > 0)
        {
            restingTime -= Time.deltaTime;
            yield return null;
        }
        usable = true;
    }
    public void ResetCD()
    {
        StopCoroutine(coolDownMethode);
        usable = true;
    }
}
