using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GnomeDeathSoundScript : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioPatch _deathPatch;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayDeathSound()
    {
        gameObject.AddComponent<AudioListener>();
        _deathPatch.Play(_audioSource);

    }
}
