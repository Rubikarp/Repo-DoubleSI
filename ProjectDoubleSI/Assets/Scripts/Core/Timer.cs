using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    public UnityEvent endGame;
    [SerializeField] private int timeLeft;
    [SerializeField] private int gameDuration;
    [SerializeField] private int gameEnd;
    [SerializeField] private bool takingTimeAway;
    [SerializeField] private TextMeshProUGUI timerDisplay;

    private void Start()
    {
        InitializeTimer();
        timerDisplay = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        RunningTimer();
        StopTimer();
    }
    private void InitializeTimer()
    {

        timeLeft = gameDuration;
    }

    public void StopTimer()
    {
        if(timeLeft <= gameEnd)
        {
            takingTimeAway = true;
            endGame.Invoke();
        }
    }
    void RunningTimer()
    {
        if(!takingTimeAway)
        {
            StartCoroutine(DecreamentTime());
        }
    }

    private IEnumerator DecreamentTime()
    {
        takingTimeAway = true;
        Debug.Log(timeLeft);
        yield return new WaitForSeconds(1f);
        timeLeft--;
        timerDisplay.text = timeLeft.ToString();
        if (timeLeft == 10 || timeLeft == 20)
        {
            Debug.Log("Alerte 10 or 20 s left");
        }

        takingTimeAway = false;
    }
}
