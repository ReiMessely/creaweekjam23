using UnityEngine;

[RequireComponent(typeof(AudioSource))]
//Handles Player Audio
public class PlayerAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    private AudioSource _shootAudioSource;
    [SerializeField] private AudioPatch _playerShootPatch;
    [SerializeField] private GnomeDeathSoundScript _playerDeathSoundScript;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _shootAudioSource = transform.GetChild(0).GetChild(0).GetComponent<AudioSource>();
    }
    public void PlayFootstep(AudioPatch patch)
    {
        patch.Play(_audioSource);
    }

    public void PlayPlayerDeathSound()
    {
        _playerDeathSoundScript.gameObject.transform.position = transform.position;
        _playerDeathSoundScript.PlayDeathSound();
    }

    public void PlayShootSound()
    {
        _playerShootPatch.Play(_shootAudioSource);
    }
}