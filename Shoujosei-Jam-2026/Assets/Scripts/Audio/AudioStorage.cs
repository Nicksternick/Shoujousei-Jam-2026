using System;
using System.Collections.Generic;
using UnityEngine;

public enum MusicTrack
{
    Overworld,
    Combat,
    BossMusic
}

public enum SoundType
{
    Hit
}

[Serializable] class SoundTuple { public SoundType soundType; public AudioClip soundClip; }
[Serializable] class MusicTuple { public MusicTrack musicType; public AudioClip musicClip; }
public class AudioStorage : MonoBehaviour
{
    [SerializeField] private List<SoundTuple> sounds;
    [SerializeField] private List<MusicTuple> tracks;

    public AudioClip GetSound(SoundType soundType)
    {
        foreach (SoundTuple soundTuple in sounds)
        {
            if (soundTuple.soundType == soundType)
            {
                return soundTuple.soundClip;
            }
        }

        return null;
    }

    public AudioClip GetMusic(MusicTrack musicType)
    {
        foreach (MusicTuple musicTuple in tracks)
        {
            if (musicTuple.musicType == musicType)
            {
                return musicTuple.musicClip;
            }
        }

        return null;
    }
}
