using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Space]
    [Header("Global")]
    [Range(0f, 1f)] public float globalDefaultVolume = 0.5f;

    [Space]
    [Header("Musics")]
    [Range(0f, 1f)] public float musicDefaultVolume = 0.5f;

    [Space]
    [Header("SFX")]
    [Range(0f, 1f)] public float sfxDefaultVolume = 0.5f;

    [Space]
    [Header("References")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    void Update()
    {
        if (musicSource.clip != null)
        {
            musicSource.volume = musicDefaultVolume * globalDefaultVolume;
        }

        if (sfxSource.clip != null)
        {
            sfxSource.volume = sfxDefaultVolume * globalDefaultVolume;
        }
    }
    public void PlayMusic(AudioClip music, float volume = 1f)
    {
        musicSource.Stop();
        musicSource.PlayOneShot(music, (musicDefaultVolume * volume) * globalDefaultVolume);

        return;
    }

    public void StopMusic()
    {
        musicSource.Stop();

        return;
    }

    public void PlaySfx(AudioClip sfx, float volume = 1f, float pitch = 1f)
    {
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(sfx, (sfxDefaultVolume * volume) * globalDefaultVolume);

        sfxSource.pitch = 1;

        return;
    }
}

