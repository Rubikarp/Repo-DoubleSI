using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDrawer : MonoBehaviour
{
    public GameScore score;

    [SerializeField] Slider scoreGauge;

    [SerializeField] TextMeshProUGUI enemyScore;
    [SerializeField] TextMeshProUGUI playerScore;
    public void UpdateScore()
    {
        scoreGauge.value = 1-score.PlayerRatio;

        playerScore.text = "Player : " + score.EnemyScore.ToString("F0");
        enemyScore.text = score.PlayerScore.ToString("F0") + " : Enemy";
    }
}
