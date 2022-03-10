using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCalculator : MonoBehaviour
{
    public ScoreEvent onPlayerScore;

    [Header("Base Data")]
    public float ingredientScore = 50f;
    public float recipeScore = 300f;

    [Header("Other Data")]
    [SerializeField] private bool feverTime;
    [Range(1, 2)] float feverTimeMult = 1.25f;
    IEnumerator feverCD;

    [field: SerializeField]
    public float FeverRestingTime { get; private set; }

    private bool nextScoreBonus;
    [Range(1, 2)] float nextScoreMult = 1.5f;

    [field: SerializeField]
    private bool nextScoreBonusDouble;
    [Range(1, 2)] float nextScoreMultDouble = 2.0f;

    public void PlayerMatch(LineMatch match)
    {
        float score = 0f;

        //Calcul Score
        foreach (var ingredient in match.ingredients)
        {
            score += ingredientScore + Mathf.Lerp(0.5f, 1.5f, ingredient.freshness * 0.01f);
        }
        if (match.recipe)
        {
            score += recipeScore;
        }

        //Bonus sup
        if (feverTime && match.isRecipe == false)
        {
            score *= feverTimeMult;
        }
        if (nextScoreBonus && match.isRecipe)
        {
            score *= nextScoreMult;
            nextScoreBonus = false;
        }

        //BonusDouble
        if (nextScoreBonusDouble && match.isRecipe)
        {
            score *= nextScoreMultDouble;
            nextScoreBonusDouble = false;
        }

        onPlayerScore?.Invoke(score);
    }

    public void FeverTime(float duration, float multiplication)
    {
        feverTimeMult = Mathf.Max(multiplication, 1.0f);
        feverTime = true;

        //Coroutine
        if (feverCD != null) StopCoroutine(feverCD);
        feverCD = FeverCD(duration);
        StartCoroutine(feverCD);
    }
    public void NextScoreBonus(float multiplication)
    {
        nextScoreBonus = true;
        nextScoreMult = Mathf.Max(multiplication, 1.0f);
    }

    public void NextScoreBonusDouble(float multiplication)
    {
        nextScoreBonusDouble = true;
        nextScoreMultDouble = Mathf.Max(multiplication, 1.0f);
    }

    private IEnumerator FeverCD(float duration)
    {
        FeverRestingTime = duration;
        while (FeverRestingTime > 0)
        {
            FeverRestingTime -= Time.deltaTime;
            yield return null;
        }
        feverTime = false;
    }
}
