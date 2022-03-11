using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScoreEvent : UnityEvent<float> { }

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
            return playerScore / TotalScore;
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

    public void PlayerScorePoint(float points)
    {
        playerScore += points;
        onScoreChange?.Invoke();

        EnemyScorePoint(points* Random.Range(0.4f, 1.1f));
    }

    public void EnemyScorePoint(float points)
    {
        enemyScore += points;
        onScoreChange?.Invoke();
    }

}
