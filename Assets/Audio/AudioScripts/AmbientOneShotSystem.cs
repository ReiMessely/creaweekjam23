using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AmbientOneShotSystem : MonoBehaviour
{
    [SerializeField] private AudioPatch _dayPatch;
    [SerializeField] private AudioPatch _nightPatch;
    [SerializeField] private GameObject _player;
    [SerializeField] private AudioMixerSnapshot _daySnapshot;
    [SerializeField] private AudioMixerSnapshot _nightSnapshot;
    private AudioSource _audioSource;
    private float _timer;
    private float _timerInterval = 15;

    private int _quadrant;



    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timerInterval)
        {
            PlayAmbientSound();
           _timer = 0;
           _timerInterval = Random.Range(15, 26);
        }
    }

    void PlayAmbientSound()
    {
        _quadrant = Random.Range(1, 5);
        switch(_quadrant)
        {
            case 1:
            {
                    transform.position = _player.transform.position + new Vector3(Random.Range(10, 26), 0, Random.Range(10, 26));
                    break;
            }
            case 2:
            {
                    transform.position = _player.transform.position + new Vector3(Random.Range(10, 26), 0, Random.Range(-10, -26));
                    break;
            }
            case 3:
            {
                    transform.position = _player.transform.position + new Vector3(Random.Range(-10, -26), 0, Random.Range(-10, -26));
                    break;
            }
            case 4:
            {
                    transform.position = _player.transform.position + new Vector3(Random.Range(-10, -26), 0, Random.Range(10, 26));
                    break;
            }
        }
        if(_daySnapshot)
        {
            _dayPatch.Play(_audioSource);
        }
        else if(_nightSnapshot)
        {
            _nightPatch.Play(_audioSource);
        }
    }
}
