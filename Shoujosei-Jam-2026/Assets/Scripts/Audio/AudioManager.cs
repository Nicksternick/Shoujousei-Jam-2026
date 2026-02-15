using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private MusicHandler musicHandler;
    [SerializeField] private SFXHandler sfxHandler;
    [SerializeField] private AudioStorage audioStorage;
    
    private static AudioManager instance;
    public static AudioManager Instance => instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void StopMusic()
    {
        musicHandler.StopTrack();
    }

    public void PlayMusic(MusicTrack track)
    {
        AudioClip clip = audioStorage.GetMusic(track);

        if (clip != null)
        {
            musicHandler.PlayTrack(clip);
        }
        else
        {
            Debug.LogError($"{track.ToString()} not found.");
        }
    }

    public void PlaySound(SoundType sound)
    {
        AudioClip clip = audioStorage.GetSound(sound);

        if (clip != null)
        {
            sfxHandler.PlaySound(clip);
        }
        else
        {
            Debug.LogError($"{sound.ToString()} not found.");
        }
    }
}
