using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class UstensilsVFX : MonoBehaviour
{
    [SerializeField] MMF_Player utensilsFeedback;
    [SerializeField] UtensilCard utensilCard;
    [SerializeField] AudioClip utensilAudioClip;

    public void Initializtion()
    {
        utensilAudioClip = utensilCard.utensil.UstensilVFX;
        utensilsFeedback.GetFeedbackOfType<MMF_Sound>().Sfx = utensilAudioClip;
    }

}
