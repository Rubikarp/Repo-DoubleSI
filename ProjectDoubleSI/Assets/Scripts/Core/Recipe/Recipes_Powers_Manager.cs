using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

    public enum RecipePowers
    {
        ToolCooldownReset,
        ScoreBonus,
        MaxManaUp
    }

[System.Serializable]
public class RecipePowerEvent : UnityEvent<RecipePowers> { }

public class Recipes_Powers_Manager : MonoBehaviour
{

    public bool scoreBonus;
    public float scoreBonusDuration;

    public void LaunchPower(RecipePowers power)
    {
        switch (power)
        {
            case RecipePowers.ToolCooldownReset:
                ToolCooldownReset();
                break;
            case RecipePowers.ScoreBonus:
                TempScoreBonus();
                break;
            case RecipePowers.MaxManaUp:
                MaxManaUp();
                break;
            default:
                Debug.LogError("Invalid Power");
                break;
        }
        
    }

    public void ToolCooldownReset()
    {
        //réduit à 0 le cooldown d'un ustensile aléatoire
    }

    public void TempScoreBonus()
    {
        //augmente de 50% le gain de score des prochaines recettes pendant 10 secondes
        StartCoroutine(ScoreBonusCoroutine());
    }

    IEnumerator ScoreBonusCoroutine()
    {
        scoreBonus = true;
        yield return new WaitForSeconds(scoreBonusDuration);
        scoreBonus = false;
    }

    public void MaxManaUp()
    {
        //ajoute un de mana max permanent
        //manaManager.maxMana = manaManager.maxMana + 1;
    }
}
