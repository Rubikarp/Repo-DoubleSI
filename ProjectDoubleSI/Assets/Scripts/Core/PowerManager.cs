using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public enum GamePowers
{
    NextRecipeScoreMult,
    ToolCooldownReset,
    NoSwitchCancel,
    TempScoreMult,
    LineDestroy,
    MaxManaUp,
}

[System.Serializable]
public class PowerEvent : UnityEvent<GamePowers> { }

public class PowerManager : MonoBehaviour
{
    [Header("Reference")]
    public ManaManager mana;
    public GameScore score;
    public List<UtensilCard> cards = new List<UtensilCard>();

    public void LaunchPower(GamePowers power)
    {
        switch (power)
        {
            case GamePowers.NextRecipeScoreMult:
                break;
            case GamePowers.ToolCooldownReset:
                ToolCooldownReset();
                break;
            case GamePowers.NoSwitchCancel:
                break;
            case GamePowers.TempScoreMult:
                TempScoreBonus();
                break;
            case GamePowers.LineDestroy:
                break;
            case GamePowers.MaxManaUp:
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
        cards.Where(card => !card.usable).ToList().Random().ResetCD();
    }

    public void TempScoreBonus()
    {
        //augmente de 50% le gain de score des prochaines recettes pendant 10 secondes
        score.FeverTime(10f, 1.5f);
    }


    public void MaxManaUp()
    {
        //ajoute un de mana max permanent
        mana.MaxManaUp(1);
    }
}
