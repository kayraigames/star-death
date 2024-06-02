using UnityEngine;
using Yarn.Unity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSourceSFX;
    public AudioSource audioSourceTrack;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //[YarnCommand("PlaySound")]
    public void PlaySound(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>($"SFX/{soundName}");
        if (clip != null)
        {
            if (audioSourceSFX.isPlaying)
            {
                audioSourceSFX.Stop();
            }
            audioSourceSFX.clip = clip;
            audioSourceSFX.Play();
        }
        else
        {
            Debug.LogWarning("Sound not found: " + soundName);
        }
    }
    //[YarnCommand("PlayTrack")]
    public void PlayTrack(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>($"Tracks/{soundName}");
        if (clip != null)
        {
            if (audioSourceTrack.isPlaying)
            {
                audioSourceTrack.Stop();
            }
            audioSourceTrack.clip = clip;
            audioSourceTrack.Play();
        }
        else
        {
            Debug.LogWarning("Sound not found: " + soundName);
        }
    }
    //[YarnCommand("StopTrack")]
    public void StopTrack(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>(soundName);
        if (clip != null)
        {
            if (audioSourceTrack.isPlaying)
            {
                audioSourceTrack.Stop();
            }
            audioSourceTrack.clip = clip;
            audioSourceTrack.Play();
        }
        else
        {
            Debug.LogWarning("Sound not found: " + soundName);
        }
    }
}