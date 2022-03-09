using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCalculator : MonoBehaviour
{
    public float ingredientScore = 50f;
    public float recipeScore = 300f;

    public ScoreEvent onPlayerScore;

    public void PlayerMatch(LineMatch match)
    {
        float score = 0f;

        foreach (var ingredient in match.ingredients)
        {
            score += ingredientScore + Mathf.Lerp(0.5f, 1.5f, ingredient.freshness * 0.01f);
        }

        if (match.recipe)
        {
            score += recipeScore;
        }

        onPlayerScore?.Invoke(score, match.recipe);
    }
}
