using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public float scoreAdverse = 0;
    //private float percentScoreAdverse;
    public float scoreJoueur = 0;
    //private float percentScoreJoueur;
    private float scoreTotal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*scoreTotal = scoreAdverse + scoreJoueur;
        percentScoreJoueur = scoreJoueur / scoreTotal * 100;
        percentScoreAdverse = 100 - percentScoreJoueur;*/
    }

    public void AddScore()
    {
        //scoreJoueur = scoreJoueur + //valeur score recette
    }
}
