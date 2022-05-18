using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioClip cardDroppedSFX;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playCardDroppedSFX()
    {
        audioSource.PlayOneShot(cardDroppedSFX);
    }
}
