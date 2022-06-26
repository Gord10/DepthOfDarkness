using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : Singleton<Music>
{
    public AudioClip gameMusic, goodEndingMusic, badEndingMusic;
    private AudioSource audioSource;

    protected override void Awake()
    {
        if(_instance)
        {
            Destroy(gameObject);
            return;
        }

        base.Awake();
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGameMusic()
    {
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    public void PlayGoodEndingMusic()
    {
        audioSource.clip = goodEndingMusic;
        audioSource.Play();
    }

    public void PlayBadEndingMusic()
    {
        audioSource.clip = badEndingMusic;
        audioSource.Play();
    }
}
