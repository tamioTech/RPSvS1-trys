using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] AudioClip sizzleSFX;
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] GameObject fuseP1Gao;
    [SerializeField] GameObject fuseP2Gao;
    //[SerializeField] Sprite bombSprite;
    //[SerializeField] Sprite explosionSprite;

    AudioSource audioSource;

    // Start is called before the first frame update

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        fuseP1Gao.SetActive(false);
        fuseP2Gao.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FusePosition()
    {

    }

    public void LightP1Fuse()
    {
        fuseP1Gao.SetActive(true);
    }

    public void NoP1Fuse()
    {
        fuseP1Gao.SetActive(false);
    }

    public void LightP2Fuse()
    {
        fuseP2Gao.SetActive(true);
    }

    public void NoP2Fuse()
    {
        fuseP2Gao.SetActive(false);
    }

    public void PlaySizzleSFX()
    {
        if (audioSource.clip == sizzleSFX) return;
        audioSource.Stop();
        audioSource.clip = sizzleSFX;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayExplosionSFX()
    {
        if (audioSource.clip == explosionSFX) return;
        audioSource.Stop();
        audioSource.clip = explosionSFX;
        audioSource.loop = false;
        audioSource.PlayOneShot(explosionSFX);
    }

    
}
