using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangProjectile : MonoBehaviour
{
    [SerializeField] static private float _maxDistance;
    [SerializeField] private float _grabRange;
    [SerializeField] private float _initialSpeed;
    [SerializeField] static private float _damage = 1;
    private GameObject _playerRef;
    private float _currentSpeed;
    private float _acceleration;
    private Vector3 _startPos;
    private bool _canDamage = true;
    private bool _isGoingBack = false;

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
            if (!_isGoingBack)
            {
                _isGoingBack = true;
                _canDamage = true;
            }
            transform.position += Time.deltaTime * _currentSpeed * ( transform.position - _playerRef.transform.position ).normalized;
        }
      
       
        float distance = Vector3.Distance(transform.position, _playerRef.transform.position);

        if (distance <= _grabRange && _currentSpeed < 0)
        {
            Kill();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.tag == "Player")
        {
          
            return;
        }

        if (!_canDamage)
        {
            return;
        }
        Health targetHealth = other.GetComponentInParent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(_damage);
            _canDamage = false;
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

    public static void AddDamage(float amount)
    {
        _damage += amount;
    }

    public static void AddDistance(float amount)
    {
        _maxDistance += amount;
    }

    public static void SetDamage(float amount) 
    {
        _damage = amount;
    }

    public static void SetDistance(float amount) 
    {
        _maxDistance = amount;
    }
}
