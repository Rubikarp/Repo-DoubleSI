using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameScoreLimits : MonoBehaviour
{
    [Header("Dependancy")]
    [SerializeField] GameScore score;
    
    [Header("Parameter")]
    [SerializeField] float limitThreshold = 100.0f;
    [SerializeField, Range(0,1)] float winningRatio = 0.9f;

    public UnityEvent onPlayerKO;
    public UnityEvent onEnnemyKO;
    private void OnEnable()
    {
        score.onScoreChange.AddListener(CheckLimits);
    }
    private void OnDisable()
    {
        score.onScoreChange.RemoveListener(CheckLimits);
    }

    public void CheckLimits()
    {
        if (score.TotalScore < limitThreshold) return;

        if((score.TotalScore / score.PlayerScore) > winningRatio)
        {
            onPlayerKO?.Invoke();
        }
        else
        if ((score.TotalScore / score.EnemyScore) > winningRatio)
        {
            onPlayerKO?.Invoke();
        }
    }
}
