using UnityEngine;

public class SFXHandler : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;

    public void PlaySound(AudioClip clip)
    {
        soundSource.clip = clip;
        soundSource.PlayOneShot(clip);
    }
}
