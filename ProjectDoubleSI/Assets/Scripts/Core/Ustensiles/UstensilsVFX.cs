using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class UstensilsVFX : MonoBehaviour
{
    MMF_Player ustensilsSFX;
    GameObject ustensils;

    // Start is called before the first frame update
    void Start()
    {
        ustensilsSFX.Initialization(ustensils);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
