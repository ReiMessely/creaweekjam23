using UnityEngine;

[RequireComponent(typeof(AudioSource))]
//Handles Player Audio
public class GhostAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    private AudioSource _attackAudioSource;
    [SerializeField] private AudioPatch _ghostMovePatch;
    [SerializeField] private AudioPatch _ghostDeathPatch;
    [SerializeField] private AudioPatch _ghostRangedAttackPatch;
    [SerializeField] private AudioPatch _ghostMeleeAttackPatch;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _attackAudioSource = transform.GetChild(0).GetComponent<AudioSource>();
    }
    private void Start()
    {
        PlayGhostMove(_ghostMovePatch);
    }
    public void PlayGhostMove(AudioPatch patch)
    {
        patch.Play(_audioSource);
    }
    public void PlayGhostMeleeAttack()
    {
        _ghostMeleeAttackPatch.Play(_attackAudioSource);
    }
    public void PlayGhostRangedAttack()
    {
        _ghostRangedAttackPatch.Play(_attackAudioSource);
    }
    public void PlayGhostDeath()
    {
        _ghostDeathPatch.PlayOneShot(_audioSource);
    }
}

