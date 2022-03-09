using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScoreEvent : UnityEvent<float, bool> { }

public class GameScore : MonoBehaviour
{
    public float TotalScore
    {
        get
        {
            return playerScore + enemyScore;
        }
    }
    public float PlayerScore
    {
        get
        {
            return playerScore;
        }
    }
    public float PlayerRatio
    {
        get
        {
            return playerScore/ TotalScore;
        }
    }
    public float EnemyScore
    {
        get
        {
            return enemyScore;
        }
    }
    [Header("Main Data")]
    [SerializeField] float playerScore = 0.0f;
    [SerializeField] float enemyScore = 0.0f;
    public UnityEvent onScoreChange;
    
    [Header("Other Data")]
    [SerializeField] private bool feverTime;
    [Range(1, 2)] float feverTimeMult = 1.3f;
    private bool nextScoreBonus;
    [Range(1, 2)] float nextScoreMult = 1.5f;

    public void PlayerScorePoint(float points, bool recipe)
    {
        if (feverTime)
        {
            points *= feverTimeMult;
        }
        if (nextScoreBonus && recipe)
        {
            points *= nextScoreMult;
            nextScoreBonus = false;
        }
        playerScore += points;

        enemyScore += points * Random.Range(0.4f, 1.4f);
        onScoreChange?.Invoke();
    }
    public void EnemyScorePoint(float points, bool recipe)
    {
        enemyScore += points;
        onScoreChange?.Invoke();
    }

    public void FeverTime(float duration, float multiplication)
    {
        feverTimeMult = Mathf.Max(multiplication, 1.0f);
        feverTime = true;
        Invoke("FeverCD", duration);
    }
    public void NextScoreBonus(float multiplication)
    {
        nextScoreBonus = true;
        nextScoreMult = Mathf.Max(multiplication, 1.0f);
    }

    private void FeverCD()
    {
        feverTime = false;
    }
}
