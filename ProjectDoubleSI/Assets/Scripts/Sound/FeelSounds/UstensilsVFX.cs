using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class UstensilsVFX : MonoBehaviour
{
    [SerializeField] MMF_Player utensilsFeedback;
    [SerializeField] UtensilSCO utensil;
    [SerializeField] AudioClip utensilAudioClip;
    
    public void Initializtion()
    {
        utensilAudioClip = utensil.UstensilVFX;
        utensilsFeedback.GetFeedbackOfType<MMF_Sound>().Sfx = utensilAudioClip; 
    }

}
