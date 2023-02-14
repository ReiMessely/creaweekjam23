using UnityEngine;

[RequireComponent(typeof(AudioSource))]
//Handles Player Audio
public class PlayerAudio : MonoBehaviour
{
    private AudioSource _audioSource;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayFootstep(AudioPatch patch)
    {
        patch.Play(_audioSource);
    }
}

