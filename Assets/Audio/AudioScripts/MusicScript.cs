using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicScript : MonoBehaviour
{
    [SerializeField] private AudioClip layer1;
    [SerializeField] private AudioClip layer2;
    [SerializeField] private AudioClip layer3;
    [SerializeField] private AudioClip layer4;
    [SerializeField] private AudioClip layer5;
    [SerializeField] private AudioClip layer6;
    [SerializeField] private AudioClip layer7;
    [SerializeField] private AudioClip nightEnd;
    [SerializeField] private AudioClip nightStart;

    private AudioSource ASlayer1;
    private AudioSource ASlayer2;
    private AudioSource ASlayer3;
    private AudioSource ASlayer4;
    private AudioSource ASlayer5;
    private AudioSource ASlayer6;
    private AudioSource ASlayer7;
    private AudioSource ASlayerNightEnd;
    private AudioSource ASlayerNightStart;

    private float maxVol = 0.1f;

    private float volume1 = 0.1f;
    private float volume2 = 0.1f;
    private float volume3 = 0.1f;
    private float volume4 = 0.1f;
    private float volume5 = 0.1f;
    private float volume6 = 0.1f;
    private float volume7 = 0.1f;
    private float volumeEnd = 0.1f;
    private float volumeStart = 0.1f;

    public float _fadeSpeed = 0.75f;



    // Start is called before the first frame update
    void Start()
    {
        volume1 = maxVol;
        volume2 = maxVol;
        volume3 = maxVol;
        volume4 = maxVol;
        volume5 = maxVol;
        volume6 = maxVol;
        volume7 = maxVol;
        volumeEnd = maxVol;
        volumeStart = maxVol;

        ASlayer1 = gameObject.AddComponent<AudioSource>();
        ASlayer1.clip = layer1;
        ASlayer1.volume = volume1;

        ASlayer2 = gameObject.AddComponent<AudioSource>();
        ASlayer2.clip = layer2;
        ASlayer2.volume = volume2;

        ASlayer3 = gameObject.AddComponent<AudioSource>();
        ASlayer3.clip = layer3;
        ASlayer3.volume = volume3;

        ASlayer4 = gameObject.AddComponent<AudioSource>();
        ASlayer4.clip = layer4;
        ASlayer4.volume = volume4;

        ASlayer5 = gameObject.AddComponent<AudioSource>();
        ASlayer5.clip = layer5;
        ASlayer5.volume = volume5;

        ASlayer6 = gameObject.AddComponent<AudioSource>();
        ASlayer6.clip = layer6;
        ASlayer6.volume = volume6;

        ASlayer7 = gameObject.AddComponent<AudioSource>();
        ASlayer7.clip = layer7;
        ASlayer7.volume = volume7;

        ASlayerNightEnd = gameObject.AddComponent<AudioSource>();
        ASlayerNightEnd.clip = nightEnd;
        ASlayer7.volume = volumeEnd;

        ASlayerNightStart = gameObject.AddComponent<AudioSource>();
        ASlayerNightStart.clip = nightStart;
        ASlayerNightStart.volume = volumeStart;

    }

    // Update is called once per frame
    void Update()
    {
        if (!ASlayer1.isPlaying)
        {
            ASlayer1.Play();
        }

        if (!ASlayer2.isPlaying)
        {
            ASlayer2.Play();
        }

        if (!ASlayer3.isPlaying)
        {
            ASlayer3.Play();
        }

        if (!ASlayer4.isPlaying)
        {
            ASlayer4.Play();
        }

        if (!ASlayer5.isPlaying)
        {
            ASlayer5.Play();
        }

        if (!ASlayer6.isPlaying)
        {
            ASlayer6.Play();
        }

        if (!ASlayer7.isPlaying)
        {
            ASlayer7.Play();
        }
      
        

    }
}
