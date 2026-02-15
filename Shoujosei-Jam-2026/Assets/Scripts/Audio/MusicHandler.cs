using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    public void StopTrack()
    {
        musicSource.Stop();
    }

    public void PlayTrack(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
}
