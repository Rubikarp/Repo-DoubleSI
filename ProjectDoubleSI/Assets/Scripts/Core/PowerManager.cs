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

    /// <summary>
    /// réduit à 0 le cooldown d'un ustensile aléatoire
    /// </summary>
    public void ToolCooldownReset()
    {
        //réduit à 0 le cooldown d'un ustensile aléatoire
        cards.Where(card => !card.usable).ToList().Random().ResetCD();
    }

    /// <summary>
    /// augmente de 50% le gain de score des prochaines recettes pendant 10 secondes
    /// </summary>
    public void TempScoreBonus()
    {
        score.FeverTime(10f, 1.5f);
    }

    /// <summary>
    /// ajoute 1 de mana max permanent
    /// </summary>
    public void MaxManaUp()
    {
        mana.MaxManaUp(1);
    }
}
