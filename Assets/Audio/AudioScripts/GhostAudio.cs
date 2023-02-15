using UnityEngine;

[RequireComponent(typeof(AudioSource))]
//Handles Player Audio
public class GhostAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioPatch _GhostMovePatch;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        PlayGhostMove(_GhostMovePatch);
    }
    public void PlayGhostMove(AudioPatch patch)
    {
        patch.Play(_audioSource);
    }
    public void PlayGhostAttack()
    {

    }
}

