using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private GameObject _target;
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _engageRange = 4.0f;
    [SerializeField] private float _attackRange = 5.0f;
    private bool _isMoving = false;
    [SerializeField] private GhostAudio _ghostAudioScript;

    [Header("Combat")]
    [SerializeField] private GameObject _projectileSocket;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _meleeBox;
    [SerializeField] private float _rateOfFire = 1;
    [SerializeField] private float _meleeDamage = 1;
    private MeleeAttack _melee;
    private bool _isShooting = false;
    private float _shootTimer;

    public GameObject Target
    {
        get { return _target; }
        set { _target = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (_engageRange > _attackRange)
        {
            _engageRange = _attackRange;
        }
        ResetShootTimer();
        _melee = _meleeBox.GetComponent<MeleeAttack>();
        _melee.EnemyScript = this;
    }
    private void OnEnable()
    {
        Health.OnDeath += OnDeath;
    }

    private void OnDisable()
    {
        Health.OnDeath -= OnDeath;
    }

    // Update is called once per frame
    private void Update()
    {
        // If we're not moving
        if (!_isMoving)
        {
            // RANGED COMBAT
            if (_projectile)
            {
                if ((_target.transform.position - transform.position).sqrMagnitude <= _attackRange * _attackRange)
                {
                    _isShooting = true;
                    // Start counting down
                    _shootTimer -= Time.deltaTime;
                    if (_shootTimer <= 0)
                    {
                        // Shoot
                        _ghostAudioScript.PlayGhostRangedAttack();
                        _projectileSocket.transform.LookAt(_target.transform);
                        Instantiate(_projectile, _projectileSocket.transform.position, _projectileSocket.transform.rotation);
                        ResetShootTimer();
                    }
                }
                else _isShooting = false;
            }
        }
        else ResetShootTimer();
    }

    
    void FixedUpdate()
    {
        // RANGED MOVEMENT
        if (_projectile)
        {
            if (((_target.transform.position - transform.position).sqrMagnitude > _engageRange * _engageRange) && !_isShooting)
            {
                _isMoving = true;
                _navMeshAgent.destination = _target.transform.position;
            }
            else
            {
                // Set navmesh destination to current position to stand still
                _isMoving = false;
                _navMeshAgent.destination = transform.position;
            }
        }
        // MELEE MOVEMENT
        else
        {
            _isMoving = true;
            _navMeshAgent.destination = _target.transform.position;
        }
    }

    private void ResetShootTimer()
    {
        _shootTimer = 1.0f / _rateOfFire;
    }

    public float Damage
    {
        get
        {
            return _meleeDamage;
        }
    }

    void OnDeath()
    {
        _ghostAudioScript.PlayGhostDeath();
    }
}
