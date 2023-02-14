using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    [SerializeField, Range(0, 30)] private float _lifetime = 5;
    private bool _isQuitting = false;

    // Start is called before the first frame update
    private void Awake()
    {
        Invoke("Kill", _lifetime);
    }

    private void OnApplicationQuit()
    {
        _isQuitting = true;
    }

    private void Kill()
    {
        // If we close the game, do not try to destroy the object, otherwise we try to delete twice
        if (_isQuitting) return;
        Destroy(gameObject);
    }

}
