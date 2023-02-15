using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AmbientLoopSystem : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioMixerSnapshot _daySnapShot;
    [SerializeField] private AudioMixerSnapshot _nightSnapShot;
    [SerializeField] private AudioMixerSnapshot _transitionSnapShot;
    [SerializeField] private AudioClip _dayAmbientLoop;
    [SerializeField] private AudioClip _nightAmbientLoop;
    private bool _isTransitioning = false;
    private bool _transitioningToNight = false;
    private float _timer;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!_isTransitioning)
        {
            
            if (_daySnapShot)
            {
                if (!_audioSource.isPlaying)
                {
                    _audioSource.clip = _dayAmbientLoop;
                    _audioSource.Play();
                }
            }
            else if (_nightSnapShot)
            {
                if (!_audioSource.isPlaying)
                {
                    _audioSource.clip = _nightAmbientLoop;
                    _audioSource.Play();
                }
            }
        }
        else if(_isTransitioning)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1.5f)
            {
               _audioSource.Stop();
                if(!_audioSource.isPlaying && _transitioningToNight)
                {
                    _nightSnapShot.TransitionTo(0f);
                    _isTransitioning = false;
                    _transitioningToNight = false;
                }
                else if(!_audioSource.isPlaying && !_transitioningToNight)
                {
                    _daySnapShot.TransitionTo(0f);
                    _isTransitioning = false;
                    _transitioningToNight = true;
                }
            }
        }
        
    }

    public void TransitionToNight()
    {
        
        _isTransitioning = true;
        _transitionSnapShot.TransitionTo(1.5f);
        _transitioningToNight = true;
        
    }
    public void TransitionToDay()
    {
        _isTransitioning = true;
        _daySnapShot.TransitionTo(1.5f);
        _transitioningToNight = false;
    }
}
