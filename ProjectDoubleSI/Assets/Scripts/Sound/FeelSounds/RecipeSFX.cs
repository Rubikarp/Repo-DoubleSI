using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class RecipeSFX : MonoBehaviour
{
    [SerializeField] MMF_Player recipeFeeback;
    [SerializeField] private AudioClip[] MatchSFXs = new AudioClip[2];


    public void SwitchSFX(LineMatch match)
    {
        if(match.isRecipe)
        {
            recipeFeeback.GetFeedbackOfType<MMF_Sound>().Sfx = MatchSFXs[0];
        }
        else recipeFeeback.GetFeedbackOfType<MMF_Sound>().Sfx = MatchSFXs[1];
    }
}
