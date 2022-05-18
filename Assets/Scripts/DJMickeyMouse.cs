using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJMickeyMouse : MonoBehaviour
{
    [SerializeField] AudioClip music;
    [SerializeField] AudioClip panicMusic;
    [SerializeField] AudioClip victoryMusic;

    DJMickeyMouse dj;
    AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (!dj)
        {
            DontDestroyOnLoad(gameObject);
            PlayMusic();
        }
    }
    void Start()
    {
        
    }

    public void PlayMusic()
    {
        if (audioSource.clip == music) return;
        audioSource.Stop();
        audioSource.clip = music;
        audioSource.Play();
    }

    public void PlayPanicMusic()
    {
        if (audioSource.clip == panicMusic) return;
        audioSource.Stop();
        audioSource.clip = panicMusic;
        audioSource.Play();
    }

    public void PlayVictoryMusic()
    {
        if (audioSource.clip == victoryMusic) return;
        audioSource.Stop();
        audioSource.clip = victoryMusic;
        audioSource.Play();
    }

}
