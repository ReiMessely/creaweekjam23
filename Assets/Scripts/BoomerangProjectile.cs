using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangProjectile : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _grabRange;
    [SerializeField] private float _initialSpeed;
    private GameObject _playerRef;
    private float _currentSpeed;
    private float _acceleration;
    private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
        _acceleration = GetDeaccel(0f, _initialSpeed, _maxDistance);
        _currentSpeed = _initialSpeed;
        _playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        _currentSpeed += _acceleration * Time.deltaTime;
      

        if (_currentSpeed > 0 )
        {
            transform.position += transform.forward * Time.deltaTime * _currentSpeed;
        }
        else
        {
       
            transform.position += Time.deltaTime * _currentSpeed * ( transform.position - _playerRef.transform.position ).normalized;
        }
      
       
        float distance = Vector3.Distance(transform.position, _playerRef.transform.position);
       
        if (distance <= _grabRange && _currentSpeed <0)
        {
            Kill();
        }
    }

    void Kill()
    {
        _playerRef.GetComponent<PlayerController>().ReturnBoomerang();
        Destroy(gameObject);

    }

    float GetDeaccel(float finalVel, float initVel, float distance)
    {
        return ((finalVel * finalVel) - (initVel * initVel)) / (distance *2);
    }
}
